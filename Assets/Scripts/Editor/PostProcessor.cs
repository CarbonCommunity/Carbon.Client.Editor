using System;
using System.Linq;
using Carbon;
using UnityEditor;
using UnityEngine;

public class ScriptPostprocessor : AssetPostprocessor
{
	protected void OnPreprocessAsset()
	{
		if (assetPath.EndsWith(".cs", StringComparison.OrdinalIgnoreCase) ||
			assetPath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
		{
			RustAsset.Scan(true);
			RustAssetProcessor.PrefabLookup?.Dispose();
		}
	}
}

