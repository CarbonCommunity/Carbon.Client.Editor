using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using Carbon;
using System;
using UnityEditor;
using System.IO;
using UnityEditor.SceneManagement;

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
		Debug.Log ( $"Loading Rust root bundle: {bundlename}" );

		backend = new AssetBundleBackend ( bundlename );

        Debug.Log ( $" Found {backend.bundles.Count:n0} bundles: {string.Join(", ", backend.bundles.Select(x => x.Key))}" );
        Debug.Log ( $" Found {backend.bundles.Sum(x => x.Value.GetAllAssetNames().Length):n0} assets..." );

		foreach(var bundle in backend.bundles)
		{
			foreach(var asset in bundle.Value.GetAllAssetNames())
			{
				if (!asset.EndsWith(".prefab"))
				{
					continue;
				}

				if (!prefabs.ContainsKey(asset)) prefabs.Add(asset, null);
			}
		}

		Debug.Log($"Prewarming complete {prefabs.Count}.");

		RustAssetProcessor.OnAssetsLoaded?.Invoke(prefabs);
	}

	public void Dispose ()
	{
		backend?.Dispose ();
		backend = null;

		Debug.Log ( $"Disposed Rust's asset bundles. Clean-up complete." );
	}
	public uint GetRustUID ( string name )
	{
		return manifest.pooledStrings.FirstOrDefault ( x => x.str == name ).hash;
	}
}
