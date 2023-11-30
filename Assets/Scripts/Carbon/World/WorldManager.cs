#if UNITY_EDITOR

using System.Threading.Tasks;
using ProtoBuf;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Carbon
{
    [ExecuteAlways]
    public class WorldManager : MonoBehaviour
    {
	    internal static WorldManager _singleton;

	    public static WorldManager Singleton => _singleton ?? (_singleton = FindObjectOfType<WorldManager>());

        #region Defines

	    public string filename => PlayerPrefs.GetString("mapfilename");
	    public Terrain Land;
        public static Terrain Water { get; private set; }
        public static Material WaterMaterial { get; private set; }
        public static float[,,] Ground { get; private set; }
        public static float[,,] Biome { get; private set; }
        public static bool[,] Alpha { get; private set; }
        public static bool AlphaDirty { get; set; } = true;
        public static int SplatMapRes { get; private set; }
        public static int HeightMapRes { get; private set; }
        public static int AlphaMapRes { get => HeightMapRes - 1; }
        public static LayerType CurrentLayerType { get; private set; }
        private static TerrainLayer[] GroundLayers = null, BiomeLayers = null, TopologyLayers = null;
        public static bool LayerDirty { get; private set; } = false;

        public enum TerrainType
        {
            Land,
            Water
        }

        public enum LayerType
        {
            Ground,
            Biome,
            Alpha,
            Topology
        }

        public struct MapInfo
        {
            public int terrainRes;
            public int splatRes;
            public Vector3 size;
            public float[,,] splatMap;
            public float[,,] biomeMap;
            public bool[,] alphaMap;
            public TerrainInfo land;
            public TerrainInfo water;
            public TerrainMap<int> topology;
            public PrefabData[] prefabData;
            public PathData[] pathData;
        }

        public struct TerrainInfo
        {
            public float[,] heights;
        }
        #endregion

        public WorldSerialization LoadWorld(string filename)
        {
            var blob = new WorldSerialization();
            blob.Load(filename);
            return blob;
        }

        public void Load(MapInfo mapInfo, string path = "")
        {
            SetTerrains(mapInfo);
            SetSplatMaps(mapInfo);
            ClearSplatMapUndo();
        }

        private void SetTerrains(MapInfo mapInfo)
        {
            HeightMapRes = mapInfo.terrainRes;
            SetupTerrain(mapInfo, Land);
        }

        private void SetupTerrain(MapInfo mapInfo, Terrain terrain)
        {
            if (terrain.terrainData.size != mapInfo.size)
            {
	            var centeredPosition = mapInfo.size / -2;
	            terrain.gameObject.SetActive(true);
	            terrain.transform.position = new Vector3(centeredPosition.x, 0, centeredPosition.z);
                terrain.terrainData.heightmapResolution = mapInfo.terrainRes;
                terrain.terrainData.size = mapInfo.size;
                terrain.terrainData.alphamapResolution = mapInfo.splatRes;
                terrain.terrainData.baseMapResolution = mapInfo.splatRes;
            }

            terrain.terrainData.SetHeights(0, 0, terrain.Equals(Land) ? mapInfo.land.heights : mapInfo.water.heights);
        }

        public void SetSplatMap(float[,,] array, LayerType layer, int topology = -1)
        {
            if (array == null)
            {
                Debug.LogError($"SetSplatMap(array) is null.");
                return;
            }

            if (layer == LayerType.Alpha)
            {
                Debug.LogWarning($"SetSplatMap(float[,,], {layer}) is not a valid layer to set. Use SetAlphaMap(bool[,]) to set {layer}.");
                return;
            }

            // Check for array dimensions not matching alphamap.
            if (array.GetLength(0) != SplatMapRes || array.GetLength(1) != SplatMapRes || array.GetLength(2) != LayerCount(layer))
            {
                Debug.LogError($"SetSplatMap(array[{array.GetLength(0)}, {array.GetLength(1)}, {LayerCount(layer)}]) dimensions invalid, should be " +
                    $"array[{ SplatMapRes}, { SplatMapRes}, {LayerCount(layer)}].");
                return;
            }

            switch (layer)
            {
                case LayerType.Ground:
                    Ground = array;
                    break;
                case LayerType.Biome:
                    Biome = array;
                    break;
            }

            if (CurrentLayerType == layer)
            {
                if (!GetTerrainLayers().Equals(Land.terrainData.terrainLayers))
                    Land.terrainData.terrainLayers = GetTerrainLayers();

                RegisterSplatMapUndo($"{layer}");
                Land.terrainData.SetAlphamaps(0, 0, array);
                LayerDirty = false;
            }
        }

        private void SetSplatMaps(MapInfo mapInfo)
        {
            SplatMapRes = mapInfo.splatRes;
            SetSplatMap(mapInfo.splatMap, LayerType.Ground);
            SetSplatMap(mapInfo.biomeMap, LayerType.Biome);
            SetAlphaMap(mapInfo.alphaMap);
        }

        public void ClearSplatMapUndo()
        {
            foreach (var tex in Land.terrainData.alphamapTextures)
                Undo.ClearUndo(tex);
        }

        public void RegisterSplatMapUndo(string name) => Undo.RegisterCompleteObjectUndo(Land.terrainData.alphamapTextures, name);
        public void SetAlphaMap(bool[,] array)
        {
            if (array == null)
            {
                Debug.LogError($"SetAlphaMap(array) is null.");
                return;
            }

            // Check for array dimensions not matching alphamap.
            if (array.GetLength(0) != AlphaMapRes || array.GetLength(1) != AlphaMapRes)
            {
                // Special case for converting Alphamaps from the Rust resolution to the Unity Editor resolution.
                if (array.GetLength(0) == SplatMapRes && array.GetLength(1) == SplatMapRes)
                {
                    if (Alpha == null || Alpha.GetLength(0) != AlphaMapRes)
                        Alpha = new bool[AlphaMapRes, AlphaMapRes];

                    Parallel.For(0, AlphaMapRes, i =>
                    {
                        for (int j = 0; j < AlphaMapRes; j++)
                            Alpha[i, j] = array[i / 2, j / 2];
                    });

                    Land.terrainData.SetHoles(0, 0, Alpha);
                    AlphaDirty = false;
                    return;
                }

                else
                {
                    Debug.LogError($"SetAlphaMap(array[{array.GetLength(0)}, {array.GetLength(1)}]) dimensions invalid, should be array[{AlphaMapRes}, {AlphaMapRes}].");
                    return;
                }
            }

            Alpha = array;
            Land.terrainData.SetHoles(0, 0, Alpha);
            AlphaDirty = false;
        }

        public TerrainLayer[] GetTerrainLayers()
        {
            if (GroundLayers == null || BiomeLayers == null || TopologyLayers == null)
                SetTerrainLayers();

            return CurrentLayerType switch
            {
                LayerType.Biome => BiomeLayers,
                _ => GroundLayers
            };
        }

        public void SetTerrainLayers()
        {
            GroundLayers = GetGroundLayers();
            BiomeLayers = GetBiomeLayers();
            AssetDatabase.SaveAssets();
        }

        private TerrainLayer[] GetGroundLayers()
        {
            TerrainLayer[] textures = new TerrainLayer[8];
            textures[0] = AssetDatabase.LoadAssetAtPath<TerrainLayer>("Assets/Resources/Textures/Ground/Dirt.terrainlayer");
            textures[0].diffuseTexture = Resources.Load<Texture2D>("Textures/Ground/dirt");
            textures[1] = AssetDatabase.LoadAssetAtPath<TerrainLayer>("Assets/Resources/Textures/Ground/Snow.terrainlayer");
            textures[1].diffuseTexture = Resources.Load<Texture2D>("Textures/Ground/snow");
            textures[2] = AssetDatabase.LoadAssetAtPath<TerrainLayer>("Assets/Resources/Textures/Ground/Sand.terrainlayer");
            textures[2].diffuseTexture = Resources.Load<Texture2D>("Textures/Ground/sand");
            textures[3] = AssetDatabase.LoadAssetAtPath<TerrainLayer>("Assets/Resources/Textures/Ground/Rock.terrainlayer");
            textures[3].diffuseTexture = Resources.Load<Texture2D>("Textures/Ground/rock");
            textures[4] = AssetDatabase.LoadAssetAtPath<TerrainLayer>("Assets/Resources/Textures/Ground/Grass.terrainlayer");
            textures[4].diffuseTexture = Resources.Load<Texture2D>("Textures/Ground/grass");
            textures[5] = AssetDatabase.LoadAssetAtPath<TerrainLayer>("Assets/Resources/Textures/Ground/Forest.terrainlayer");
            textures[5].diffuseTexture = Resources.Load<Texture2D>("Textures/Ground/forest");
            textures[6] = AssetDatabase.LoadAssetAtPath<TerrainLayer>("Assets/Resources/Textures/Ground/Stones.terrainlayer");
            textures[6].diffuseTexture = Resources.Load<Texture2D>("Textures/Ground/stones");
            textures[7] = AssetDatabase.LoadAssetAtPath<TerrainLayer>("Assets/Resources/Textures/Ground/Gravel.terrainlayer");
            textures[7].diffuseTexture = Resources.Load<Texture2D>("Textures/Ground/gravel");

            return textures;
        }

        private TerrainLayer[] GetBiomeLayers()
        {
            TerrainLayer[] textures = new TerrainLayer[4];
            textures[0] = AssetDatabase.LoadAssetAtPath<TerrainLayer>("Assets/Resources/Textures/Biome/Arid.terrainlayer");
            textures[0].diffuseTexture = Resources.Load<Texture2D>("Textures/Biome/arid");
            textures[1] = AssetDatabase.LoadAssetAtPath<TerrainLayer>("Assets/Resources/Textures/Biome/Temperate.terrainlayer");
            textures[1].diffuseTexture = Resources.Load<Texture2D>("Textures/Biome/temperate");
            textures[2] = AssetDatabase.LoadAssetAtPath<TerrainLayer>("Assets/Resources/Textures/Biome/Tundra.terrainlayer");
            textures[2].diffuseTexture = Resources.Load<Texture2D>("Textures/Biome/tundra");
            textures[3] = AssetDatabase.LoadAssetAtPath<TerrainLayer>("Assets/Resources/Textures/Biome/Arctic.terrainlayer");
            textures[3].diffuseTexture = Resources.Load<Texture2D>("Textures/Biome/arctic");
            return textures;
        }

        public int LayerCount(LayerType layer)
        {
            return layer switch
            {
                LayerType.Ground => 8,
                LayerType.Biome => 4,
                _ => 2
            };
        }
    }
}
#endif
