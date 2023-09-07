using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	public List<Asset> Assets = new();

	internal readonly string _mainBundle = "Addon";

	[Serializable]
	public class Asset
	{
		[Tooltip("Keep it lowercase please. (For consistency purposes)")]
		public string Name;
		[Tooltip("Leave empty for default (.bundle).")]
		public string Extension;
		public GameObject[] Prefabs;
	}

#if UNITY_EDITOR
	public void Build()
	{
		var name = Name.Replace(" ", "_").ToLower();
		var path = EditorUtility.SaveFilePanel("Export Carbon Addon", Defines.Root, $"{name}_{Version}", "cca");

		if (string.IsNullOrEmpty(path))
		{
			Debug.Log($"Cancelled building Carbon addon.");
			return;
		}

		var bundles = new List<AssetBundleBuild>();

		foreach (var asset in Assets)
		{
			var bundle = new AssetBundleBuild();
			var bundleName = name;
			var bundleVariant = string.IsNullOrEmpty(asset.Extension) ? "bundle" : asset.Extension;

			bundle.assetBundleName = bundleName;
			bundle.assetBundleVariant = bundleVariant;
			bundle.assetNames = asset.Prefabs.Select(x => AssetDatabase.GetAssetPath(x)).ToArray();

			bundles.Add(bundle);
		}

		var folder = Defines.GetBundleDirectory(forAddon: this);
		var result = BuildPipeline.BuildAssetBundles(folder, bundles.ToArray(), BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
		var assets = new List<Carbon.Client.Assets.Asset>();

		foreach (var asset in Assets)
		{
			var bundleName = name;
			var bundleVariant = string.IsNullOrEmpty(asset.Extension) ? "bundle" : asset.Extension;
			assets.Add(new Carbon.Client.Assets.Asset()
			{
				Name = bundleName,
				Data = File.ReadAllBytes(Path.Combine(folder, $"{bundleName}.{bundleVariant}"))
			});
		}

		var addon = Carbon.Client.Assets.Addon.Create(new Carbon.Client.Assets.Addon.AddonInfo
		{
			Name = Name,
			Author = Author,
			Description = Description,
			Version = Version
		}, assets.ToArray());
		addon.StoreToFile(path.Replace(".cca", string.Empty));
	}

	public void PrepareScene()
	{
		var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
		scene.name = $"{Name} v{Version} by {Author}";
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
				prefabInstance.name = $"{prefab.name} (Preview)";
				prefabInstance.transform.SetParent(go.transform, false);
			}
		}
	}
#endif
}
