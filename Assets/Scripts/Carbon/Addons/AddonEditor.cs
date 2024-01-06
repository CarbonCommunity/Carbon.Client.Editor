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
	public static Type[] UnwantedMonos = new[]
	{
		typeof(CustomProceduralObject),
		typeof(CustomProceduralObjectEntry)
	};

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

			var processedCache = new List<Transform>();

			Prefabs.RemoveAll(x => x == null);

			foreach (var prefab in Prefabs)
			{
				Recursive(prefab.transform);

				void Recursive(Transform transform)
				{
					var components = transform.GetComponents<RustComponent>();
					{
						foreach (var component in components)
						{
							if(!processedCache.Contains(component.transform))
							{
								component.name = $"{component.name}_{Guid.NewGuid():N}";
								processedCache.Add(component.transform);
							}

							var path = GetRecursiveName(transform).ToLower();

							if (!Components.TryGetValue(path, out var comps))
							{
								Components.Add(path, comps = new List<RustComponent>());
							}

							comps.Add(component);
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

					var monoBehaviours = transform.GetComponents<MonoBehaviour>();
					for (int i = 0; i < monoBehaviours.Length; i++)
					{
						var component = monoBehaviours[i];

						if (UnwantedMonos.Contains(component.GetType()))
						{
							DestroyImmediate(component);
							i--;
						}
					}

					foreach (var subTransform in transform)
					{
						Recursive((Transform)subTransform);
					}
				}
			}

			processedCache.Clear();
			processedCache = null;

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

						if (prefab.gameObject == root)
						{
							continue;
						}

						prefab.gameObject.SetActive(false);
						DestroyImmediate(prefab, true);
					}
					catch(Exception ex)
					{
						if (prefab != null)
						{
							Debug.LogError($"[{Name}] Clear failure for [{prefab.gameObject.name}] '{prefab.Path}' {prefab.Position} ({ex.Message})\n{ex.StackTrace}");
						}
						else
						{
							Debug.LogError($"[{Name}] {ex.Message}\n{ex.StackTrace}");
						}
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
		Distinct();

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
			var bundleName = $"{asset.Name}_{this.name}";
			var bundleVariant = string.IsNullOrEmpty(asset.Extension) ? _defaultVariant : asset.Extension;

			bundle.assetBundleName = bundleName;
			bundle.assetBundleVariant = bundleVariant;
			bundle.assetNames = asset.Prefabs.Select(AssetDatabase.GetAssetPath).ToArray();

			bundles.Add(bundle);
		}
		void PostprocessAsset(Asset asset)
		{
			var bundleName = $"{asset.Name}_{this.name}";
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
							RustPath = prefab.Path,
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

		if(Scene.Prefabs.Count > 0) PostprocessAsset(Scene);
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

		Carbon.Rcon.Singleton.SendMap(BuildPath);
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

	public void Distinct()
	{
		Models.Prefabs.RemoveAll(x => Scene.Prefabs.Contains(x));
		Scene.Prefabs.RemoveAll(x => Models.Prefabs.Contains(x));
		Models.Prefabs = Models.Prefabs.Distinct().ToList();
		Scene.Prefabs = Scene.Prefabs.Distinct().ToList();
	}

	public void FetchModels()
	{
		Scene.BuildCache(this);
	}

	public static void ResetEditor()
	{
		RustAsset.Scan(true);
		RustAssetProcessor.PrefabLookup?.Dispose();
		RconEntity.ClearAll();
		EditorCoroutine.Start(RustAssetProcessor.Preview());
		Defines.OnReload();
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

				var height = GUILayout.Height(25);

				if (GUILayout.Button("Build", height))
				{
					addon.Build();
				}

				if (GUILayout.Button("Open Scene", height))
				{
					addon.PrepareScene();
				}

				EditorGUILayout.EndHorizontal();

				if (GUILayout.Button("Fetch Models"))
				{
					addon.FetchModels();
				}

				GUILayout.Space(15);

				GUILayout.Label("Rcon", EditorStyles.boldLabel);
				GUILayout.Space(5);

				if (!Rcon.Singleton.IsConnected)
				{
					var rcon = Rcon.Singleton;

					GUILayout.BeginHorizontal();
					rcon.Ip = EditorGUILayout.TextField("IP & Port", rcon.Ip);
					rcon.Port = EditorGUILayout.IntField(string.Empty, rcon.Port, GUILayout.Width(100));
					GUILayout.EndHorizontal();

					rcon.Password = EditorGUILayout.PasswordField("Password", rcon.Password);

					if (GUILayout.Button(rcon.IsConnected ? "Disconnect" : "Connect"))
					{
						if (rcon.IsConnected)
						{
							rcon.Disconnect();
						}
						else
						{
							rcon.Connect();
						}
					}
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

						if (GUILayout.Button($"Update on Server ({Carbon.Rcon.Singleton.Ip}:{Carbon.Rcon.Singleton.Port})"))
						{
							Carbon.Rcon.Singleton.SendMap(addon.BuildPath);
						}
					}
				}
			}
		}
	}
#endif
}
