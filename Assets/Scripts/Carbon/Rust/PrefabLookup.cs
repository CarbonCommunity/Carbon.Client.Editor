using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Carbon;
using UnityEditor;
using Carbon.Client;
using System.Collections;

public class PrefabLookup : System.IDisposable
{
	public AssetBundleBackend backend;

	public Dictionary<string, GameObject> prefabs = new();

	internal GameManifest manifest;

	~PrefabLookup()
	{
		Dispose();
	}

	public IEnumerator Build(int progressParentId, string bundlename)
	{
		backend = new AssetBundleBackend(bundlename);
		const string filter = ".prefab";

#if UNITY_EDITOR
		var bundleProgress = Progress.Start($"Bundle Load", string.Empty, parentId: progressParentId);
#endif

		foreach (var bundle in backend.bundles)
		{
			var content = bundle.Value.GetAllAssetNames().Where(x => x.EndsWith(filter));
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
