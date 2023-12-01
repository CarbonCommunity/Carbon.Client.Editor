using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Carbon;
using Carbon.Client;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WorldManager))]
public class WorldManagerEditor : Editor
{
    internal Color _originalBackground;
    internal Color _originalForeground;
    internal List<string> _errors = new(10);
    internal Vector2 _prefabScroll;

    public string PrintErrors => string.Join("\n", _errors);
    int mapLandHeight = 500;

    public void Error(object error)
    {
        _errors.Add(error.ToString());
    }
    public void ErrorCheck()
    {
        _errors.Clear();

        var manager = (WorldManager)target;
        if (!string.IsNullOrEmpty(manager.filename) && !File.Exists(manager.filename))
            Error("Invalid file");
    }

    public void OnEnable()
    {
        mapLandHeight = PlayerPrefs.GetInt("maplandheight", 500);
    }

    public override void OnInspectorGUI()
    {
        ErrorCheck();

        var worldManager = (WorldManager)target;

        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((WorldManager)target), typeof(WorldManager), false);
        GUI.enabled = true;

        worldManager.Land = (Terrain)EditorGUILayout.ObjectField("Land", worldManager.Land, typeof(Terrain), true);
        GUILayout.BeginHorizontal();
        {
            PlayerPrefs.SetString("mapfilename", EditorGUILayout.TextField("Rust .MAP File", worldManager.filename));

            using (CarbonUtils.GUIColorChange.New(Color.cyan, false))
            {
                if (GUILayout.Button("Find", GUILayout.Width(75)))
                {
                    var previous = worldManager.filename;
                    var folder = EditorUtility.OpenFilePanelWithFilters("Rust .MAP File", Defines.Root, new string[] { "Rust Map File", "map" });

                    if (string.IsNullOrEmpty(folder))
                    {
                        Debug.Log($"Cancelled looking for the Rust map file.");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(previous) && previous != folder && RustAssetProcessor.Instance.IsLoaded)
                        {
                            Debug.LogWarning($"Changing Rust map file - unloading currently loaded map.");
                        }

                        PlayerPrefs.SetString("mapfilename", folder);
                    }
                }
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        mapLandHeight = EditorGUILayout.IntSlider("Land Height (Water is 500)", mapLandHeight, 1000, 1);
        worldManager.Land.gameObject.transform.position = new Vector3(worldManager.Land.gameObject.transform.position.x, -mapLandHeight, worldManager.Land.gameObject.transform.position.z);

        using (CarbonUtils.GUIColorChange.New(Color.green, false))
        {
            if (GUILayout.Button("Save", GUILayout.Width(75)))
            {
                PlayerPrefs.SetInt("maplandheight", mapLandHeight);
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        {
            GUILayout.BeginVertical();
            {
                using (CarbonUtils.GUIColorChange.New(Color.green, true))
                {
                    if (GUILayout.Button("Load Map"))
                    {
                        WorldSerialization world = worldManager.LoadWorld(worldManager.filename);
                        if (world == null || world.world == null) { Debug.LogError("Couldnt load map file."); return; }
                        PlayerPrefs.SetInt("maplandheight", mapLandHeight);
                        WorldManager.Singleton.Load(WorldConverter.WorldToTerrain(world), worldManager.filename);
                    }
                }
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndHorizontal();

        GUI.enabled = true;

        if (_errors.Count > 0)
        {
            EditorGUILayout.HelpBox(PrintErrors, MessageType.Error);
        }
    }
}
