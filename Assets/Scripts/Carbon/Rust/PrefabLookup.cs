﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Carbon;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.IO;
using ProtoBuf.Meta;

public class PrefabLookup : System.IDisposable
{
	public AssetBundleBackend backend;

	public Dictionary<string, GameObject> prefabs = new();

	internal GameManifest manifest;

	~PrefabLookup()
	{
		Dispose();
	}

	public IEnumerator Load(AssetBundleBackend backend, string assetRoot)
	{
		backend.isError = false;
		backend.assetPath = System.IO.Path.GetDirectoryName(assetRoot) + System.IO.Path.DirectorySeparatorChar;

		var request = AssetBundle.LoadFromFileAsync(assetRoot);
		while (!request.isDone)
		{
			yield return null;
		}

		backend.rootBundle = request.assetBundle;

		if (backend.rootBundle == null)
		{
			backend.LoadError("Couldn't load root AssetBundle - " + assetRoot);
			yield break;
		}

		var manifestList = backend.rootBundle.LoadAllAssets<AssetBundleManifest>();
		if (manifestList.Length != 1)
		{
			backend.LoadError("Couldn't find AssetBundleManifest - " + manifestList.Length);
			yield break;
		}

		backend.manifest = manifestList[0];

		foreach (var ab in backend.manifest.GetAllAssetBundles())
		{
#if UNITY_EDITOR
			var coroutine = EditorCoroutine.Start(backend.LoadBundle(ab));

			while (!coroutine.IsDone)
			{
				yield return null;
			}
#else
			yield return backend.LoadBundle(ab);
#endif
		}

		backend.BuildFileIndex();
	}

	public IEnumerator Build(int progressParentId, string bundlename)
	{
		backend = new AssetBundleBackend();

#if UNITY_EDITOR
		var coroutine = EditorCoroutine.Start(Load(backend, bundlename));

		while (!coroutine.IsDone)
		{
			yield return null;
		}
#else
		yield return Load(backend, bundlename);
#endif

		const string prefabFilter = ".prefab";

#if UNITY_EDITOR
		var bundleProgress = Progress.Start($"Bundle Load", string.Empty, parentId: progressParentId);
#endif

		foreach (var bundle in backend.bundles)
		{
			var content = bundle.Value.GetAllAssetNames().Where(x => x.EndsWith(prefabFilter));
			var count = 1;
			var totalCount = content.Count();

#if UNITY_EDITOR
			Progress.SetDescription(bundleProgress, bundle.Key);
#endif

			foreach (var asset in content)
			{
				if (!prefabs.ContainsKey(asset)) prefabs.Add(asset, null);
				count++;

#if UNITY_EDITOR
				Progress.Report(bundleProgress, count.Percentage(totalCount, 1f));
#endif

				if (count % 100 == 0)
				{
					yield return null;
				}
			}

			yield return null;
		}

#if UNITY_EDITOR
		Progress.Finish(bundleProgress);
#endif

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
