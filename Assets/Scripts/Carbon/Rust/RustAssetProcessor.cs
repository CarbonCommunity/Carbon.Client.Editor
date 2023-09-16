using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Carbon.Client;
using UnityEditor;
using UnityEngine;

namespace Carbon
{
	[ExecuteAlways]
	public class RustAssetProcessor : MonoBehaviour
	{
		public static RustAssetProcessor Instance { get; private set; }

		public string RustClientDirectory;
		public bool AutoLoad;
		public bool CreateVisuals;
		public bool SelectionSync;
		public float TickRate;

		public bool IsLoaded => PrefabLookup != null && PrefabLookup.backend != null && PrefabLookup.backend.bundles.Count > 0;

		public static bool IsLoading = false;
		public static Dictionary<string, GameObject> Prefabs;
		public static Action<Dictionary<string, GameObject>> OnAssetsLoaded;
		public static PrefabLookup PrefabLookup;

		internal float _currentTick;

#if UNITY_EDITOR
		public static Transform SelectedPreview
		{
			get
			{
				var select = Selection.activeGameObject;

				if (select == null)
				{
					return null;
				}

				var go = select.transform;

				while (go != null && go.parent != null)
				{
					if (go.parent == Defines.Singleton?.PreviewHub)
					{
						return go;
					}

					go = go.parent;
				}

				return go;
			}
		}
#endif

		public RustAssetProcessor()
		{
			Instance = this;
		}

#if UNITY_EDITOR
		public IEnumerator Load()
		{
			if (IsLoading)
			{
				yield break;
			}

			IsLoading = true;

			if (string.IsNullOrEmpty(RustClientDirectory))
			{
				yield break;
			}

			var id = Progress.Start("Rust Client Content", $"Rust location: {RustClientDirectory}", Progress.Options.Managed);
			var bundles = Path.Combine(RustClientDirectory, "Bundles", "Bundles");

			OnAssetsLoaded += prefabs =>
			{
				Prefabs = prefabs;

				var id2 = Progress.Start("Prefab Cache", string.Empty, Progress.Options.Managed, parentId: id);

				var count = 0;
				foreach (var prefab in Prefabs)
				{
					if (!prefab.Key.EndsWith(".prefab"))
					{
						continue;
					}

					count++;

					var assetName = prefab.Key.Replace("assets", string.Empty);
					var path = $"assets/bundled/rust/{assetName}";
					var directory = Path.GetDirectoryName(path);

					if (!Directory.Exists(directory))
					{
						Directory.CreateDirectory(directory);
					}

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
  m_Layer: 0
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
					Progress.SetDescription(id2, $"Processing game content {count} / {Prefabs.Count}");
					Progress.Report(id2, count.Percentage(Prefabs.Count, 1f));
				}

				RustAsset.Scan(true);
				RustAsset.PreviewAll();

				Progress.Finish(id2);
				Progress.Finish(id);

				IsLoading = false;
			};

			PrefabLookup = new PrefabLookup();
			EditorCoroutine.Start(PrefabLookup.Build(id, bundles));
		}
#endif
		public void Unload()
		{
			IsLoading = false;
			PrefabLookup?.Dispose();
		}

#if UNITY_EDITOR
		public void SelectionSyncTick()
		{
			if (!SelectionSync || Selection.activeObject is RustAsset)
			{
				return;
			}

			var select = SelectedPreview;

			if (select == null)
			{
				return;
			}

			foreach (var asset in RustAsset.assets)
			{
				if (asset._instance.transform == select)
				{
					Selection.activeGameObject = asset.gameObject;
					Selection.activeObject = asset;
					break;
				}
			}
		}
		public void AssetTick()
		{
			var objects = Selection.gameObjects;

			if (objects.Length > 0)
			{
				foreach (var gameObject in objects)
				{
					if (!gameObject.scene.IsValid())
					{
						UnityEngine.Debug.Log($"Yeet");
						continue;
					}

					gameObject.GetComponent<RustAsset>()?.Tick();
				}
			}
			else
			{
				if (Selection.activeObject is RustAsset asset)
				{
					asset.Tick();
				}
			}
		}

		public void Update()
		{
			var timeSince = Time.time - _currentTick;

			if (timeSince <= TickRate)
			{
				return;
			}

			_currentTick = Time.time;

			if (!IsLoaded && !IsLoading && AutoLoad)
			{
				EditorCoroutine.Start(Load());
			}

			SelectionSyncTick();
			AssetTick();
		}

#endif
	}
}
