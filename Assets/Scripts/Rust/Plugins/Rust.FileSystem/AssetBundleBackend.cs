using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class AssetBundleBackend : FileSystemBackend, System.IDisposable
{
	public AssetBundle rootBundle;
	public AssetBundleManifest manifest;
	public Dictionary<string, AssetBundle> bundles = new Dictionary<string, AssetBundle>(System.StringComparer.OrdinalIgnoreCase);
	public Dictionary<string, AssetBundle> files = new Dictionary<string, AssetBundle>(System.StringComparer.OrdinalIgnoreCase);
	public string assetPath;

	public IEnumerator Load(string assetRoot)
	{
		isError = false;
		assetPath = System.IO.Path.GetDirectoryName(assetRoot) + System.IO.Path.DirectorySeparatorChar;

		var request = AssetBundle.LoadFromFileAsync(assetRoot);
		while (!request.isDone)
		{
			yield return null;
		}

		rootBundle = request.assetBundle;

		if (rootBundle == null)
		{
			LoadError("Couldn't load root AssetBundle - " + assetRoot);
			yield break;
		}

		var manifestList = rootBundle.LoadAllAssets<AssetBundleManifest>();
		if (manifestList.Length != 1)
		{
			LoadError("Couldn't find AssetBundleManifest - " + manifestList.Length);
			yield break;
		}

		manifest = manifestList[0];

		foreach (var ab in manifest.GetAllAssetBundles())
		{
			Debug.Log($"{ab}");
			yield return LoadBundle(ab);
			yield return null;
		}

		BuildFileIndex();
	}

	public IEnumerator LoadBundle(string bundleName)
	{
		if (bundles.ContainsKey(bundleName) || bundleName.Contains("private"))
		{
			yield break;
		}

		var fileLocation = assetPath + bundleName;
		var asset = AssetBundle.LoadFromFileAsync(fileLocation);

		while (!asset.isDone)
		{
			yield return null;
		}

		if (asset == null)
		{
			LoadError("Couldn't load AssetBundle - " + fileLocation);
			yield break;
		}

		bundles.Add(bundleName, asset.assetBundle);
	}

	public void BuildFileIndex()
	{
		files.Clear();

		foreach (var bundle in bundles)
		{
			foreach (var filename in bundle.Value.GetAllAssetNames())
			{
				files.Add(filename, bundle.Value);
			}
		}
	}

	public void Dispose()
	{
		manifest = null;

		foreach (var bundle in bundles)
		{
			try
			{
				bundle.Value?.Unload(true);
			}
			catch { }

			if (bundle.Value != null)
			{
				Object.DestroyImmediate(bundle.Value);
			}
		}
		bundles.Clear();

		if (rootBundle)
		{
			rootBundle.Unload(true);
			Object.DestroyImmediate(rootBundle);
			rootBundle = null;
		}
	}

	protected override T LoadAsset<T>(string filePath)
	{
		AssetBundle bundle = null;

		if (!files.TryGetValue(filePath, out bundle))
		{
			return null;
		}

		return bundle.LoadAsset<T>(filePath);
	}

	protected override string[] LoadAssetList(string folder, string search)
	{
		var list = new List<string>();

		foreach (var file in files.Where(x => x.Key.StartsWith(folder, System.StringComparison.InvariantCultureIgnoreCase)))
		{
			if (!string.IsNullOrEmpty(search) && file.Key.IndexOf(search, System.StringComparison.InvariantCultureIgnoreCase) == -1)
				continue;

			list.Add(file.Key);
		}

		return list.ToArray();
	}
}
