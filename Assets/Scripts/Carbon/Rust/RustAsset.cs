using System.Linq;
using Carbon;
using UnityEngine;

[ExecuteInEditMode]
public class RustAsset : MonoBehaviour
{
	public string Path;

	internal GameObject _instance;
	internal float _timeSinceRetry;

	public void Awake()
	{
		Debug.Log($"Spawned {Path} {RustAssetProcessor.Prefabs} {RustAssetProcessor.PrefabLookup} {RustAssetProcessor.PrefabLookup?.backend} {RustAssetProcessor.PrefabLookup.backend.cache.Count} '{RustAssetProcessor.PrefabLookup.backend.LoadPrefab(Path)}'");

		ProcessPreview();

		RustAssetProcessor.OnAssetsLoaded += prefabs =>
		{
			ProcessPreview();
		};
	}
	public void ProcessPreview()
	{
		// if (_instance != null || RustAssetProcessor.Prefabs == null)
		// {
		// 	return;
		// }

		Debug.Log($"1");
		var prefab = RustAssetProcessor.PrefabLookup.backend.LoadPrefab(Path);
		Debug.Log($"2 {prefab}");

		if (prefab != null)
		{
			Debug.Log($"3 {prefab}");

			_instance = Instantiate(prefab);
			_instance.transform.SetParent(transform);
			_instance.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			_instance.SetActive(true);
			Debug.Log($"2 {_instance}");
		}
	}

	public void Cleanup()
	{
		if(_instance == null)
		{
			return;
		}

		Destroy(_instance);
		_instance = null;
	}

	public void OnGUI()
	{

	}
}
