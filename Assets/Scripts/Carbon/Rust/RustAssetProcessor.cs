using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Carbon.Client;
using UnityEditor;
using UnityEngine;

namespace Carbon
{
	public class RustAssetProcessor : MonoBehaviour
	{
		public static Dictionary<string, GameObject> Prefabs;
		public static Action<Dictionary<string, GameObject>> OnAssetsLoaded;
		public static PrefabLookup PrefabLookup;

		[RuntimeInitializeOnLoadMethod]
		static void RunOnStart()
		{
			Debug.Log("Disposing brain matter");
			PrefabLookup.Dispose();
		}

		public void Awake()
		{
			Load();
		}

		[ContextMenu("Load")]
		public void Load()
		{
			var folder = $@"D:\Software\Steam\steamapps\common\Rust\Bundles";
			var bundles = Path.Combine(folder, "Bundles");

			PrefabLookup = new PrefabLookup(bundles);

			OnAssetsLoaded += prefabs =>
			{
				Prefabs = prefabs;

				Debug.Log($"Done! Got {prefabs.Count} prefabs.");

#if UNITY_EDITOR
				var count = 1;
				foreach(var prefab in Prefabs)
				{
					var assetName = Path.GetFileName(prefab.Key);

					if(!assetName.EndsWith(".prefab"))
					{
						continue;
					}

					var path = $"assets/bundled/rust/{assetName}";

					if (!File.Exists(path))
					{
						var codegen = $@"%YAML 1.1
%TAG !u! tag:unity3d.com,2011:
--- !u!1 &1084888157825929651
GameObject:
  m_ObjectHideFlags: 0
  m_CorrespondingSourceObject: {{fileID: 0}}
  m_PrefabInstance: {{fileID: 0}}
  m_PrefabAsset: {{fileID: 0}}
  serializedVersion: 6
  m_Component:
  - component: {{fileID: 7282809360880194197}}
  - component: {{fileID: 7436625876820886793}}
  m_Layer: {prefab.Value.layer}
  m_Name: {prefab.Key}
  m_TagString: Untagged
  m_Icon: {{fileID: 0}}
  m_NavMeshLayer: 0
  m_StaticEditorFlags: 0
  m_IsActive: 1
--- !u!4 &7282809360880194197
Transform:
  m_ObjectHideFlags: 0
  m_CorrespondingSourceObject: {{fileID: 0}}
  m_PrefabInstance: {{fileID: 0}}
  m_PrefabAsset: {{fileID: 0}}
  m_GameObject: {{fileID: 1084888157825929651}}
  m_LocalRotation: {{x: 0, y: 0, z: 0, w: 1}}
  m_LocalPosition: {{x: 0, y: 0, z: 0}}
  m_LocalScale: {{x: 1, y: 1, z: 1}}
  m_ConstrainProportionsScale: 0
  m_Children: []
  m_Father: {{fileID: 0}}
  m_RootOrder: 0
  m_LocalEulerAnglesHint: {{x: 0, y: 0, z: 0}}
--- !u!114 &7436625876820886793
MonoBehaviour:
  m_ObjectHideFlags: 0
  m_CorrespondingSourceObject: {{fileID: 0}}
  m_PrefabInstance: {{fileID: 0}}
  m_PrefabAsset: {{fileID: 0}}
  m_GameObject: {{fileID: 1084888157825929651}}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {{fileID: 11500000, guid: fb9b096131538b44289fa56784e3fc62, type: 3}}
  m_Name: 
  m_EditorClassIdentifier: 
  Path: {prefab.Key}
";

						File.WriteAllText(path, codegen);
					}

					//var saveablePrefab = new GameObject(prefab.Key);
					//var asset = saveablePrefab.AddComponent<RustAsset>();
					//asset.Path = prefab.Key;

					// PrefabUtility.SaveAsPrefabAsset(saveablePrefab, $"assets/bundled/rust/{assetName}");

					EditorUtility.DisplayProgressBar("Processing prefabs", $"Current {count} / {Prefabs.Count}: {prefab.Key}", count.Percentage(Prefabs.Count, 1f));
					count++;
				}

				EditorUtility.ClearProgressBar();
#endif
			};
		}

		[ContextMenu("Unload")]
		public void Unload()
		{
			PrefabLookup.Dispose();
		}
	}
}
