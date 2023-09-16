using System;
using System.Collections;
using System.Collections.Generic;
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
			RustAssetProcessor.PrefabLookup?.Dispose();
		}
	}
}

