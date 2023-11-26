using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Carbon.Client;
using ProtoBuf;
using Carbon.Client.Packets;

#if UNITY_EDITOR
using Carbon;
using HierarchyIcons;
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

[CreateAssetMenu(fileName = "NewAddon", menuName = "Carbon/New Addon")]
public class AddonEditor : ScriptableObject
{
	public string Name = "New Addon";
	public string Author = "YourName";

	[TextArea(4, 10)]
	public string Description = "Here's more information about this awesome addon I've made.";
	public string Version = "1.0.0";
	public Asset Scene = new Asset { Name = "scene", Extension = "carbon" };
	public Asset Models = new Asset { Name = "models", Extension = "carbon" };

	internal readonly string _defaultVariant = "data";

	public string BuildPath => Path.Combine(Defines.Root, "Addons", $"{this.name}_{Version}.cca");

	[Serializable]
	public class Asset
	{
		[Tooltip("Keep it lowercase please. (For consistency purposes)")]
		public string Name;
		[Tooltip("Leave empty for default (.bundle).")]
		public string Extension;
		public List<GameObject> Prefabs;

		public Dictionary<string, List<RustComponent>> Components = new Dictionary<string, List<RustComponent>>();
		public Dictionary<Transform, RustAsset> RustPrefabs = new Dictionary<Transform, RustAsset>();

#if UNITY_EDITOR
		public void Preprocess()
		{
			BackUp();
			Clear();

			RustAsset.Scan(true);
		}
		public void Postprocess()
		{
			Restore();
			BackUpCleanup();
		}

		public void BuildCache(AddonEditor editor)
		{
			Components.Clear();
			RustPrefabs.Clear();

			foreach (var prefab in Prefabs)
			{
				Recursive(prefab.transform);

				void Recursive(Transform transform)
				{
					var component = transform.GetComponent<RustComponent>();
					{
						if (component != null)
						{
							transform.name = $"{transform.name}_{Guid.NewGuid():N}";

							var path = GetRecursiveName(transform).ToLower();

							if (!Components.TryGetValue(path, out var components))
							{
								Components.Add(path, components = new List<RustComponent>());
							}

							components.Add(component);
						}
					}

					var rustAsset = transform.GetComponent<RustAsset>();
					{
						if (rustAsset != null)
						{
							if (rustAsset.Model.PrefabReference != null)
							{
								Recursive(rustAsset.Model.PrefabReference.transform);
							}

							if (rustAsset.Model.PrefabReference != null && !editor.Models.Prefabs.Contains(rustAsset.Model.PrefabReference))
							{
								editor.Models.Prefabs.Add(rustAsset.Model.PrefabReference);
							}

							if (!RustPrefabs.ContainsKey(transform))
							{
								RustPrefabs.Add(transform, rustAsset);
							}
						}
					}

					foreach (var subTransform in transform)
					{
						Recursive((Transform)subTransform);
					}
				}
			}

			Debug.Log($"[{Name}] Found {Components.Count} components");
		}
		public void BackUp()
		{
			foreach (var prefab in Prefabs)
			{
				var path = AssetDatabase.GetAssetPath(prefab);
				File.WriteAllText($"{path}.bkp", File.ReadAllText(path));
			}
		}
		public void BackUpCleanup()
		{
			foreach (var prefab in Prefabs)
			{
				var path = AssetDatabase.GetAssetPath(prefab);
				File.Delete($"{path}.bkp");
			}
		}
		public void Clear()
		{
			Debug.Log($"[{Name}] Destroying {RustPrefabs.Count} RustPrefabs");

			var roots = new List<GameObject>();

			foreach (var rustPrefab in RustPrefabs)
			{
				try
				{
					rustPrefab.Value.Cache();

					var root = rustPrefab.Value.transform.root.gameObject;

					if (!roots.Contains(root))
					{
						roots.Add(root);
					}

					DestroyImmediate(rustPrefab.Value.gameObject, true);
				}
				catch(Exception ex)
				{
					Debug.LogError($"[{Name}] Clear failure for '{rustPrefab.Value.Path}' {rustPrefab.Value.Position} ({ex.Message})\n{ex.StackTrace}");
				}
			}

			foreach (var prefab in Prefabs)
			{
				Recursive(prefab.transform);

				void Recursive(Transform transform)
				{
					if (transform == null)
					{
						return;
					}

					var path = GetRecursiveName(transform).ToLower();

					foreach (var subTransform in transform)
					{
						Recursive((Transform)subTransform);
					}

					if (Components.TryGetValue(path, out var components))
					{
						foreach (var component in components)
						{
							var root = component.transform.root;

							if (!roots.Contains(root.gameObject))
							{
								roots.Add(root.gameObject);
							}

							DestroyImmediate(component, true);
						}
					}
				}
			}

			foreach (var root in roots)
			{
				Debug.Log($"Found {root} {AssetDatabase.GetAssetPath(root)}");
				AssetDatabase.SaveAssetIfDirty(root);
			}

			AssetDatabase.SaveAssets();
		}
		public void Restore()
		{
			foreach (var prefab in Prefabs)
			{
				var path = AssetDatabase.GetAssetPath(prefab);
				try
				{
					File.Copy($"{path}.bkp", path, true);
				}
				catch(Exception ex)
				{
					Debug.LogError($"Borked: {ex}");
				}
			}
		}
#endif
	}

	public static string GetRecursiveName(Transform transform, string strEndName = "")
	{
		var text = transform.name;

		if (!string.IsNullOrEmpty(strEndName))
		{
			text = text + "/" + strEndName;
		}

		if (transform.parent != null)
		{
			text = GetRecursiveName(transform.parent, text);
		}

		return text;
	}

#if UNITY_EDITOR
	public void Build()
	{
		Defines.OnPreAddonBuild();

		var path = BuildPath;
		var name = Name.Replace(" ", "_").ToLower();

		if (string.IsNullOrEmpty(path))
		{
			Debug.Log($"Cancelled building Carbon addon.");
			return;
		}

		var bundles = new List<AssetBundleBuild>();
		var folder = Defines.GetBundleDirectory(forAddon: this);
		var assets = new List<Carbon.Client.Assets.Asset>();

		void PreprocessAsset(Asset asset)
		{
			asset.BuildCache(this);
			asset.Preprocess();

			var bundle = new AssetBundleBuild();
			var bundleName = asset.Name;
			var bundleVariant = string.IsNullOrEmpty(asset.Extension) ? _defaultVariant : asset.Extension;

			bundle.assetBundleName = bundleName;
			bundle.assetBundleVariant = bundleVariant;
			bundle.assetNames = asset.Prefabs.Select(AssetDatabase.GetAssetPath).ToArray();

			bundles.Add(bundle);
		}
		void PostprocessAsset(Asset asset)
		{
			var bundleName = asset.Name;
			var bundleVariant = string.IsNullOrEmpty(asset.Extension) ? _defaultVariant : asset.Extension;

			using (var memory = new MemoryStream())
			{
				Serializer.Serialize(memory, new RustBundle
				{
					Components = asset.Components,
					RustPrefabs = asset.RustPrefabs.Select(x => new RustPrefab
					{
						Entity = x.Value.Entity,
						Model = x.Value.Model,
						Path = x.Value.Path,
						Position = BaseVector.ToProtoVector(x.Value.Position),
						Rotation = BaseVector.ToProtoVector(x.Value.Rotation),
						Scale = BaseVector.ToProtoVector(x.Value.Scale)
					}).ToList()
				});

				var bundlePath = Path.Combine(folder, $"{bundleName}.{bundleVariant}");

				if (!File.Exists(bundlePath))
				{
					Debug.LogError($"Couldn't process asset! Not found: {bundlePath}");
				}
				else
				{
					assets.Add(new Carbon.Client.Assets.Asset()
					{
						Name = asset.Name,
						Data = File.ReadAllBytes(bundlePath),
						AdditionalData = memory.ToArray()
					});

					asset.Postprocess();
				}
			}
		}

		PreprocessAsset(Scene);
		if(Models.Prefabs.Count > 0) PreprocessAsset(Models);

		foreach (var prefab in Scene.Prefabs)
		{
			AssetDatabase.SaveAssetIfDirty(prefab);
		}

		var result = BuildPipeline.BuildAssetBundles(folder, bundles.ToArray(), BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);

		PostprocessAsset(Scene);
		if(Models.Prefabs.Count > 0) PostprocessAsset(Models);

		var addon = Carbon.Client.Assets.Addon.Create(new Carbon.Client.Assets.Addon.AddonInfo
		{
			Name = Name,
			Author = Author,
			Description = Description,
			Version = Version
		}, assets.ToArray());
		addon.StoreToFile(path.Replace(".cca", string.Empty));

		assets.Clear();
		assets = null;

		Defines.OnPostAddonBuild();
	}

	public void BuildAndRconTest()
	{
		Build();

		if (Scene.Prefabs.Count == 0)
		{
			return;
		}

		Carbon.Rcon.Singleton.SendMap(BuildPath, AssetDatabase.GetAssetPath(Scene.Prefabs[0]).ToLower());
	}

	public void PrepareScene()
	{
		var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
		scene.name = $"{Name} v{Version}";

		var firstEnabled = false;
		var project = new GameObject("Project");
		SceneManager.MoveGameObjectToScene(project, scene);
		var projectInstance = project.AddComponent<Carbon.Project>();
		projectInstance.Editor = this;
		var icon = project.AddComponent<HierarchyIcon>();
		icon.icon = Resources.Load<Texture2D>("addonicon2");

		var go = new GameObject(Scene.Name);
		SceneManager.MoveGameObjectToScene(go, scene);

		if (!firstEnabled)
		{
			go.SetActive(true);
			firstEnabled = true;
		}
		else
		{
			go.SetActive(false);
		}

		foreach (var prefab in Scene.Prefabs)
		{
			var prefabInstance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
			prefabInstance.name = prefab.name;
			prefabInstance.transform.SetParent(go.transform, false);
		}

		Selection.SetActiveObjectWithContext(project, this);
		SceneManager.SetActiveScene(Defines.Singleton.gameObject.scene);
	}

	public void FetchModels()
	{
		Scene.BuildCache(this);
	}
#endif

#if UNITY_EDITOR
	[CustomEditor(typeof(AddonEditor), true)]
	public class AddonEditorEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			var addon = (AddonEditor)target;

			//
			// Tools Area
			//
			{
				GUILayout.Space(16);

				GUILayout.Label("Tools", EditorStyles.boldLabel);

				EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));

				if (GUILayout.Button("Build"))
				{
					addon.Build();
				}

				if (GUILayout.Button("Open Scene"))
				{
					addon.PrepareScene();
				}

				EditorGUILayout.EndHorizontal();

				if (GUILayout.Button("Fetch Models"))
				{
					addon.FetchModels();
				}

				using (CarbonUtils.GUIEnableChange.New(Rcon.Singleton.IsConnected))
				{
					GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					using (CarbonUtils.GUIColorChange.New(Rcon.Singleton.IsConnected ? Color.green : Color.grey, false))
					{
						GUILayout.Label(Rcon.Singleton.IsConnected ? "RCON successfully connected!" : "RCON is not connected.");
					}
					GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();

					using (CarbonUtils.GUIColorChange.New(Rcon.Singleton.IsConnected ? Color.green : Color.gray, false))
					{
						if (GUILayout.Button($"Build + Update on Server ({Carbon.Rcon.Singleton.Ip}:{Carbon.Rcon.Singleton.Port})"))
						{
							addon.BuildAndRconTest();
						}

						var prefab = addon.Scene.Prefabs.FirstOrDefault();

						if (GUILayout.Button($"Update '{(prefab == null ? "unknown" : prefab.name)}' on Server ({Carbon.Rcon.Singleton.Ip}:{Carbon.Rcon.Singleton.Port})"))
						{
							Carbon.Rcon.Singleton.SendMap(addon.BuildPath, AssetDatabase.GetAssetPath(prefab).ToLower());
						}
					}
				}
			}
		}
	}
#endif
}
