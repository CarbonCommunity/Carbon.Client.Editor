using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Carbon;
using Carbon.Client;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RustAssetProcessor))]
public class RustAssetProcessorEditor : Editor
{
	internal Color _originalBackground;
	internal Color _originalForeground;
	internal List<string> _errors = new(10);
	internal Vector2 _prefabScroll;

	public string PrintErrors => string.Join("\n", _errors);

	public void Error(object error)
	{
		_errors.Add(error.ToString());
	}
	public void ErrorCheck()
	{
		_errors.Clear();

		var processor = (RustAssetProcessor)target;

		if (!string.IsNullOrEmpty(processor.RustClientDirectory) && !Directory.Exists(processor.RustClientDirectory))
		{
			Error("Invalid directory");
		}
	}

	public override void OnInspectorGUI()
	{
		ErrorCheck();

		var processor = (RustAssetProcessor)target;
		var lookup = RustAssetProcessor.PrefabLookup;

		GUI.enabled = false;
		EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((RustAssetProcessor)target), typeof(RustAssetProcessor), false);
		GUI.enabled = true;

		GUILayout.BeginHorizontal();
		{
			processor.CreateVisuals = EditorGUILayout.Toggle("Create Visuals", processor.CreateVisuals);

			using (CarbonUtils.GUIColorChange.New(Color.cyan, false))
			{
				if (GUILayout.Button("Refresh", GUILayout.Width(75)))
				{
					RustAsset.Scan(true);
				}
			}

			using (CarbonUtils.GUIColorChange.New(Color.yellow, true))
			{
				if (GUILayout.Button("Tick", GUILayout.Width(40)))
				{
					foreach (var asset in RustAsset.assets)
					{
						asset.Tick();
					}
				}
			}
		}
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		{
			PlayerPrefs.GetString("rustclientdir", EditorGUILayout.TextField("Rust Client Directory", processor.RustClientDirectory));

			using (CarbonUtils.GUIColorChange.New(Color.cyan, false))
			{
				if (GUILayout.Button("Search", GUILayout.Width(75)))
				{
					var previous = processor.RustClientDirectory;
					var folder = EditorUtility.OpenFolderPanel("Rust Client Directory", Defines.Root, "Rust");

					if (string.IsNullOrEmpty(folder))
					{
						Debug.Log($"Cancelled looking for the Rust client directory.");
					}
					else
					{
						if (!string.IsNullOrEmpty(previous) && previous != folder && processor.IsLoaded)
						{
							Debug.LogWarning($"Changing Rust folder - unloading currently loaded bundles.");
							processor.Unload();
						}

						PlayerPrefs.SetString("rustclientdir", folder);
					}
				}
			}
		}
		GUILayout.EndHorizontal();

		processor.SelectionSync = EditorGUILayout.Toggle("Selection Sync", processor.SelectionSync);
		processor.UpdateTickRate = EditorGUILayout.Slider("Update Tick Rate", processor.UpdateTickRate, 0.01f, 1f);
		processor.PreviewTickRate = EditorGUILayout.Slider("Preview Tick Rate", processor.PreviewTickRate, 0.01f, 1f);

		EditorGUILayout.Space();
		EditorGUILayout.Separator();
		EditorGUILayout.Space();

		var isValid = !string.IsNullOrEmpty(processor.RustClientDirectory) && Directory.Exists(processor.RustClientDirectory);

		GUILayout.BeginHorizontal();
		{
			if (processor.IsLoaded)
			{
				GUILayout.BeginVertical();
				{
					using (CarbonUtils.GUIColorChange.New(Color.red, true))
					{
						if (GUILayout.Button("Unload"))
						{
							processor.Unload();
						}
					}

					EditorGUILayout.Separator();
					GUILayout.Label("Stats", EditorStyles.boldLabel);
					using (CarbonUtils.GUIColorChange.New(Color.white, false))
					{
						using (CarbonUtils.GUIEnableChange.New(false))
						{
							EditorGUILayout.TextField($"Bundles", lookup.backend?.bundles?.Count.ToString("n0"));

							if (lookup != null && lookup.backend != null && lookup.backend.bundles != null)
							{
								foreach (var bundle in lookup.backend.bundles)
								{
									EditorGUILayout.TextField($" ", bundle.Key);
								}
							}

							EditorGUILayout.TextField($"Prefabs", lookup.prefabs?.Count.ToString("n0"));
						}
					}

					if (processor.AutoLoad)
					{
						using (CarbonUtils.GUIColorChange.New(Color.green))
						{
							processor.AutoLoad = EditorGUILayout.Toggle("Auto-Load", processor.AutoLoad);
						}
					}
					else
					{
						processor.AutoLoad = EditorGUILayout.Toggle("Auto-Load", processor.AutoLoad);
					}
					EditorGUILayout.HelpBox("If the project is recompiling scripts, the bundle cache gets removed from memory.\nThis will automatically re-load bundles.", MessageType.Info);
				}
				GUILayout.EndVertical();
			}
			else
			{
				GUILayout.BeginVertical();
				{
					GUI.enabled = isValid;

					if (!isValid)
					{
						EditorGUILayout.BeginHorizontal();
						GUILayout.FlexibleSpace();
						GUILayout.Label("You haven't set the directory of your Rust client directory,\nwhich is required in order for the asset procesor to be valid.");
						GUILayout.FlexibleSpace();
						EditorGUILayout.EndHorizontal();
					}

					using (CarbonUtils.GUIColorChange.New(Color.green))
					{
						if (GUILayout.Button("Load"))
						{
							EditorCoroutine.Start(processor.Load());
						}
					}

					if (processor.AutoLoad)
					{
						using (CarbonUtils.GUIColorChange.New(Color.green))
						{
							processor.AutoLoad = EditorGUILayout.Toggle("Auto-Load", processor.AutoLoad);
						}
					}
					else
					{
						processor.AutoLoad = EditorGUILayout.Toggle("Auto-Load", processor.AutoLoad);
					}
					EditorGUILayout.HelpBox("If the project is recompiling scripts, the bundle cache gets removed from memory.\nThis will automatically re-load bundles.", MessageType.Info);

				}
				GUILayout.EndVertical();
			}
		}
		GUILayout.EndHorizontal();

		GUI.enabled = true;

		if(_errors.Count > 0)
		{
			EditorGUILayout.HelpBox(PrintErrors, MessageType.Error);
		}
	}
}
