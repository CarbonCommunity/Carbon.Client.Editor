using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Carbon.Client;
using ProtoBuf;
using Carbon.Client.Packets;

#if UNITY_EDITOR
using Carbon;
using HierarchyIcons;
using Newtonsoft.Json;
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
		public Dictionary<string, List<RustAsset>> RustPrefabs = new Dictionary<string, List<RustAsset>>();

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

							var path = AssetDatabase.GetAssetPath(transform.root).ToLower();

							if (!RustPrefabs.TryGetValue(path, out var prefabs))
							{
								RustPrefabs.Add(path, prefabs = new());
							}

							prefabs.Add(rustAsset);
						}
					}

					foreach (var subTransform in transform)
					{
						Recursive((Transform)subTransform);
					}
				}
			}

			Debug.Log($"[{Name}] Found {Components.Count} components, {RustPrefabs.Count} Rust prefabs");
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
				foreach (var prefab in rustPrefab.Value)
				{
					try
					{
						prefab.Cache();

						var root = prefab.transform.root.gameObject;

						if (!roots.Contains(root))
						{
							roots.Add(root);
						}

						Debug.Log($"{GetRecursiveName(root.transform)}: \n" +
							$"IsPartOfAnyPrefab: {PrefabUtility.IsPartOfAnyPrefab(root)}\n" +
							$"IsPartOfImmutablePrefab: {PrefabUtility.IsPartOfImmutablePrefab(root)}\n"+
							$"IsPartOfModelPrefab: {PrefabUtility.IsPartOfModelPrefab(root)}\n"+
							$"IsPartOfNonAssetPrefabInstance: {PrefabUtility.IsPartOfNonAssetPrefabInstance(root)}\n"+
							$"IsPartOfPrefabAsset: {PrefabUtility.IsPartOfPrefabAsset(root)}\n"+
							$"IsPartOfPrefabInstance: {PrefabUtility.IsPartOfPrefabInstance(root)}\n"+
							$"IsPartOfPrefabThatCanBeAppliedTo: {PrefabUtility.IsPartOfPrefabThatCanBeAppliedTo(root)}\n"+
							$"IsPartOfRegularPrefab: {PrefabUtility.IsPartOfRegularPrefab(root)}\n"+
							$"IsPartOfVariantPrefab: {PrefabUtility.IsPartOfVariantPrefab(root)}\n"+
							$"IsPrefabAssetMissing: {PrefabUtility.IsPrefabAssetMissing(root)}\n");

						if (prefab.gameObject != root)
						{
							prefab.gameObject.SetActive(false);
							DestroyImmediate(prefab, true);
						}
					}
					catch(Exception ex)
					{
						Debug.LogError($"[{Name}] Clear failure for [{prefab.gameObject.name}] '{prefab.Path}' {prefab.Position} ({ex.Message})\n{ex.StackTrace}");
					}
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
				var rustPrefabs = new Dictionary<string, List<RustPrefab>>();

				foreach (var rustPrefab in asset.RustPrefabs)
				{
					var prefabName = rustPrefab.Key;

					if (!rustPrefabs.TryGetValue(prefabName, out var prefabs))
					{
						rustPrefabs.Add(prefabName, prefabs = new());
					}

					foreach (var prefab in rustPrefab.Value)
					{
						prefabs.Add(new RustPrefab
						{
							Entity = prefab.Entity,
							Model = prefab.Model,
							Path = prefab.Path,
							Position = BaseVector.ToProtoVector(prefab.Position),
							Rotation = BaseVector.ToProtoVector(prefab.Rotation),
							Scale = BaseVector.ToProtoVector(prefab.Scale)
						});
					}
				}

				Serializer.Serialize(memory, new RustBundle
				{
					Components = asset.Components,
					RustPrefabs = rustPrefabs
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
		File.WriteAllText(path.Replace(".cca", ".cca.manifest"),
			$"{JsonConvert.SerializeObject(addon.GetManifest(), Formatting.Indented)}\n\n" +
			$"{Metadata(Scene)}\n{Metadata(Models)}");

		string Metadata(Asset asset)
		{
			var builder = new StringBuilder();

			builder.AppendLine($"{asset.Name}.{asset.Extension}");
			builder.AppendLine(string.Empty);
			builder.AppendLine($"  Prefabs:");
			foreach (var fabs in asset.Prefabs)
			{
				builder.AppendLine($"  - {GetRecursiveName(fabs.transform)}");
			}
			builder.AppendLine($"  Rust Prefabs:");
			foreach (var fabs in asset.RustPrefabs)
			{
				builder.AppendLine($"  - {fabs.Key}");

				foreach (var rustPrefabs in fabs.Value)
				{
					builder.AppendLine($"  {rustPrefabs.Path} {rustPrefabs.Position} {rustPrefabs.Rotation}");
				}
			}

			var result = builder.ToString();

			builder.Clear();
			builder = null;

			return result;
		}

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
