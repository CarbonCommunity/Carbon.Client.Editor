using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Carbon.Client;
using ProtoBuf;

#if UNITY_EDITOR
using HierarchyIcons;
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

[CreateAssetMenu(fileName = "NewAddon", menuName = "Carbon/New Addon")]
public class AddonEditor : ScriptableObject
{
	public string Name;
	public string Author;

	[TextArea(4, 10)]
	public string Description;
	public string Version;
	public List<Asset> Assets = new List<Asset>();

	internal readonly string _mainBundle = "main";
	internal readonly string _defaultVariant = "dat";

	[Serializable]
	public class Asset
	{
		[Tooltip("Keep it lowercase please. (For consistency purposes)")]
		public string Name;
		[Tooltip("Leave empty for default (.bundle).")]
		public string Extension;
		public GameObject[] Prefabs;

		public Dictionary<string, List<RustComponent>> Components = new Dictionary<string, List<RustComponent>>();

		public void Preprocess()
		{
			ClearComponents();
		}
		public void Postprocess()
		{
			ApplyComponents();
		}

		public void BuildCache()
		{
			Components.Clear();

			foreach (var prefab in Prefabs)
			{
				Recursive(prefab.transform);

				void Recursive(Transform transform)
				{
					var component = transform.GetComponent<RustComponent>();

					if (component != null)
					{
						var path = GetRecursiveName(transform).ToLower();

						if (!Components.TryGetValue(path, out var components))
						{
							Components.Add(path, components = new List<RustComponent>());
						}

						components.Add(component);
					}

					foreach (var subTransform in transform)
					{
						Recursive((Transform)subTransform);
					}
				}
			}

			Debug.Log($"[{Name}] Found {Components.Count} components");
		}
		public void ClearComponents()
		{
			foreach (var prefab in Prefabs)
			{
				Recursive(prefab.transform);

				void Recursive(Transform transform)
				{
					var path = GetRecursiveName(transform).ToLower();

					if (Components.TryGetValue(path, out var components))
					{
						foreach(var component in components)
						{
							DestroyImmediate(component, true);
						}
					}

					foreach (var subTransform in transform)
					{
						Recursive((Transform)subTransform);
					}
				}
			}
		}
		public void ApplyComponents()
		{
			foreach (var prefab in Prefabs)
			{
#if UNITY_EDITOR
				PrefabUtility.UnpackAllInstancesOfPrefab(prefab, PrefabUnpackMode.Completely, InteractionMode.UserAction);
#endif

				var prefabPath = GetRecursiveName(prefab.transform).ToLower();

				Recursive(prefab.transform);

				void Recursive(Transform transform)
				{
					var path = GetRecursiveName(transform).ToLower();

					if (Components.TryGetValue(path, out var components))
					{
						var gameObject = transform.gameObject;

						foreach (var component in components)
						{
							var realComponent = gameObject.AddComponent<RustComponent>();
							realComponent.Component = component.Component;
							realComponent.Server = component.Server;
							realComponent.Client = component.Client;
							realComponent.ColorSwitch = component.ColorSwitch;
						}
					}

					foreach (var subTransform in transform)
					{
						Recursive((Transform)subTransform);
					}
				}

#if UNITY_EDITOR
				PrefabUtility.SavePrefabAsset(prefab);
				EditorUtility.SetDirty(prefab);
#endif
			}
		}
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
		var path = EditorUtility.SaveFilePanel("Export Carbon Addon", Defines.Root, $"{this.name}_{Version}", "cca");
		var name = Name.Replace(" ", "_").ToLower();

		if (string.IsNullOrEmpty(path))
		{
			Debug.Log($"Cancelled building Carbon addon.");
			return;
		}

		var bundles = new List<AssetBundleBuild>();

		foreach (var asset in Assets)
		{
			asset.BuildCache();
			asset.Preprocess();

			var bundle = new AssetBundleBuild();
			var bundleName = asset.Name;
			var bundleVariant = string.IsNullOrEmpty(asset.Extension) ? _defaultVariant : asset.Extension;

			bundle.assetBundleName = bundleName;
			bundle.assetBundleVariant = bundleVariant;
			bundle.assetNames = asset.Prefabs.Select(AssetDatabase.GetAssetPath).ToArray();

			bundles.Add(bundle);
		}

		var folder = Defines.GetBundleDirectory(forAddon: this);
		var result = BuildPipeline.BuildAssetBundles(folder, bundles.ToArray(), BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
		var assets = new List<Carbon.Client.Assets.Asset>();

		foreach (var asset in Assets)
		{
			var bundleName = asset.Name;
			var bundleVariant = string.IsNullOrEmpty(asset.Extension) ? _defaultVariant : asset.Extension;

			using (var memory = new MemoryStream())
			{
				Serializer.Serialize(memory, new RustBundle
				{
					Components = asset.Components
				});

				assets.Add(new Carbon.Client.Assets.Asset()
				{
					Name = asset.Name,
					Data = File.ReadAllBytes(Path.Combine(folder, $"{bundleName}.{bundleVariant}")),
					AdditionalData = memory.ToArray()
				});
			}

			asset.Postprocess();
		}

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
	}

	public void PrepareScene()
	{
		var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
		scene.name = $"{Name} v{Version}";
		SceneManager.SetActiveScene(scene);

		var firstEnabled = false;
		var project = new GameObject("Project");
		var projectInstance = project.AddComponent<Carbon.Project>();
		projectInstance.Editor = this;
		var icon = project.AddComponent<HierarchyIcon>();
		icon.icon = Resources.Load<Texture2D>("addonicon2");

		foreach (var asset in Assets)
		{
			var go = new GameObject(asset.Name);

			if (!firstEnabled)
			{
				go.SetActive(true);
				firstEnabled = true;
			}
			else
			{
				go.SetActive(false);
			}

			foreach (var prefab in asset.Prefabs)
			{
				var prefabInstance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
				prefabInstance.name = prefab.name;
				prefabInstance.transform.SetParent(go.transform, false);
			}
		}

		Selection.SetActiveObjectWithContext(project, this);
	}
#endif
}
