#if UNITY_EDITOR

using UnityEngine;
using System.Threading.Tasks;
using static Carbon.WorldManager;
using System;
using System.Collections.Generic;

namespace Carbon
{
    public static class WorldConverter
    {
        public static float[,] ShortMapToFloatArray(TerrainMap<short> terrainMap)
        {
            float[,] array = new float[terrainMap.res, terrainMap.res];
            int arrayLength = array.GetLength(0);
            Parallel.For(0, arrayLength, i =>
            {
                for (int j = 0; j < arrayLength; j++)
                    array[i, j] = BitUtility.Short2Float(terrainMap[i, j]);
            });
            return array;
        }

        public static byte[] FloatArrayToByteArray(float[,] array)
        {
            short[] shortArray = new short[array.GetLength(0) * array.GetLength(1)];
            int arrayLength = array.GetLength(0);
            Parallel.For(0, arrayLength, i =>
            {
                for (int j = 0; j < arrayLength; j++)
                    shortArray[(i * arrayLength) + j] = BitUtility.Float2Short(array[i, j]);
            });
            byte[] byteArray = new byte[shortArray.Length * 2];
            Buffer.BlockCopy(shortArray, 0, byteArray, 0, byteArray.Length);
            return byteArray;
        }

        public static MapInfo ConvertMaps(MapInfo terrains, TerrainMap<byte> splatMap, TerrainMap<byte> biomeMap, TerrainMap<byte> alphaMap)
        {
            terrains.splatMap = new float[splatMap.res, splatMap.res, 8];
            terrains.biomeMap = new float[biomeMap.res, biomeMap.res, 4];
            terrains.alphaMap = new bool[alphaMap.res, alphaMap.res];

            var groundTask = Task.Run(() =>
            {
                Parallel.For(0, terrains.splatRes, i =>
                {
                    for (int j = 0; j < terrains.splatRes; j++)
                        for (int k = 0; k < 8; k++)
                            terrains.splatMap[i, j, k] = BitUtility.Byte2Float(splatMap[k, i, j]);
                });
            });

            var biomeTask = Task.Run(() =>
            {
                Parallel.For(0, terrains.splatRes, i =>
                {
                    for (int j = 0; j < terrains.splatRes; j++)
                        for (int k = 0; k < 4; k++)
                            terrains.biomeMap[i, j, k] = BitUtility.Byte2Float(biomeMap[k, i, j]);
                });
            });

            var alphaTask = Task.Run(() =>
            {
                Parallel.For(0, terrains.splatRes, i =>
                {
                    for (int j = 0; j < terrains.splatRes; j++)
                    {
                        if (alphaMap[0, i, j] > 0)
                            terrains.alphaMap[i, j] = true;
                        else
                            terrains.alphaMap[i, j] = false;
                    }
                });
            });
            Task.WaitAll(groundTask, biomeTask, alphaTask);
            return terrains;
        }

        public static MapInfo WorldToTerrain(WorldSerialization world)
        {
            MapInfo terrains = new MapInfo();
            var terrainSize = new Vector3(world.world.size, 1000, world.world.size);
            var terrainMap = new TerrainMap<short>(world.GetMap("terrain").data, 1);
            var heightMap = new TerrainMap<short>(world.GetMap("height").data, 1);
            var waterMap = new TerrainMap<short>(world.GetMap("water").data, 1);
            var splatMap = new TerrainMap<byte>(world.GetMap("splat").data, 8);
            var topologyMap = new TerrainMap<int>(world.GetMap("topology").data, 1);
            var biomeMap = new TerrainMap<byte>(world.GetMap("biome").data, 4);
            var alphaMap = new TerrainMap<byte>(world.GetMap("alpha").data, 1);

            terrains.topology = topologyMap;
            terrains.pathData = new WorldSerialization.PathData[0];
            terrains.prefabData = new WorldSerialization.PrefabData[0];

            terrains.terrainRes = heightMap.res;
            terrains.splatRes = splatMap.res;
            terrains.size = terrainSize;

            var heightTask = Task.Run(() => ShortMapToFloatArray(heightMap));
            var waterTask = Task.Run(() => ShortMapToFloatArray(waterMap));
            terrains = ConvertMaps(terrains, splatMap, biomeMap, alphaMap);
            Task.WaitAll(heightTask, waterTask);

            terrains.land.heights = heightTask.Result;
            terrains.water.heights = waterTask.Result;
            return terrains;
        }

        public static WorldSerialization TerrainToWorld(WorldSerialization oldWorld)
        {
            WorldSerialization world = new WorldSerialization();
            world.world.size = (uint)Singleton.Land.terrainData.size.x;
            world.world.prefabs = new List<WorldSerialization.PrefabData>();
            world.world.paths = new List<WorldSerialization.PathData>();

            var textureResolution = SplatMapRes;
            byte[] splatBytes = new byte[textureResolution * textureResolution * 8];
            var splatMap = new TerrainMap<byte>(splatBytes, 8);

            var splatTask = Task.Run(() =>
            {
                Parallel.For(0, 8, i =>
                {
                    for (int j = 0; j < textureResolution; j++)
                        for (int k = 0; k < textureResolution; k++)
                            splatMap[i, j, k] = BitUtility.Float2Byte(Ground[j, k, i]);
                });
                splatBytes = splatMap.ToByteArray();
            });

            splatTask.Wait();

            byte[] landHeightBytes = FloatArrayToByteArray(Singleton.Land.terrainData.GetHeights(0, 0, HeightMapRes, HeightMapRes));
            foreach (WorldSerialization.MapData data in oldWorld.world.maps)
            {
                WorldSerialization.MapData map = new WorldSerialization.MapData();
                map.name = data.name;

                switch (data.name)
                {
                    case "height":
                    case "terrain":
                        map.data = landHeightBytes;
                        break;

                    case "splat":
                        map.data = splatBytes;
                        break;

                    default:
                        map.data = data.data;
                        break;
                }

                world.world.maps.Add(map);
            }

            return world;
        }
    }
}
#endif
