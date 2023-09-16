using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Carbon;
using Carbon.Client;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

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
			processor.RustClientDirectory = EditorGUILayout.TextField("Rust Client Directory", processor.RustClientDirectory);

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

						processor.RustClientDirectory = folder;
					}
				}
			}
		}
		GUILayout.EndHorizontal();

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
							EditorGUILayout.TextField($"Bundles", lookup.backend.bundles.Count.ToString("n0"));

							foreach(var bundle in lookup.backend.bundles)
							{
								EditorGUILayout.TextField($" ", bundle.Key);
							}

							EditorGUILayout.TextField($"Prefabs", lookup.prefabs.Count.ToString("n0"));
						}
					}
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
							processor.Load();
						}
					}

					if (processor.AutoLoad)
					{
						using (CarbonUtils.GUIColorChange.New(Color.green))
						{
							processor.AutoLoad = GUILayout.Toggle(processor.AutoLoad, "Auto-Load");
						}
					}
					else
					{
						processor.AutoLoad = GUILayout.Toggle(processor.AutoLoad, "Auto-Load");
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
