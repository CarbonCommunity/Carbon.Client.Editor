using System;
using Carbon;
using UnityEditor;

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

