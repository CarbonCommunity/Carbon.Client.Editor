using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using Carbon;
using System;
using UnityEditor;
using System.IO;
using UnityEditor.SceneManagement;
using Carbon.Client;

public class PrefabLookup : System.IDisposable
{
	public AssetBundleBackend backend;

	public Dictionary<string, GameObject> prefabs = new();

	internal GameManifest manifest;

	~PrefabLookup()
	{
		Dispose();
	}

	public PrefabLookup ( string bundlename )
	{
		backend = new AssetBundleBackend ( bundlename );

		const string filter = ".prefab";

		foreach (var bundle in backend.bundles)
		{
			var content = bundle.Value.GetAllAssetNames().Where(x => x.EndsWith(filter));
			var count = 1;
			var totalCount = content.Count();

			foreach (var asset in content)
			{
#if UNITY_EDITOR
				EditorUtility.DisplayProgressBar("Rust Content", $"Caching assets... {count:n0} / {totalCount:n0}", count.Percentage(totalCount, 1));
#endif
				if (!prefabs.ContainsKey(asset)) prefabs.Add(asset, null);
				count++;
			}
		}

		EditorUtility.ClearProgressBar();

		RustAssetProcessor.OnAssetsLoaded?.Invoke(prefabs);
	} 

	public void Dispose ()
	{
		backend?.Dispose ();
		backend = null;
	}
	public uint GetRustUID ( string name )
	{
		return manifest.pooledStrings.FirstOrDefault ( x => x.str == name ).hash;
	}
}
