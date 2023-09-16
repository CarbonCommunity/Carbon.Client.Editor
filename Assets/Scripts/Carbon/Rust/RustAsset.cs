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
		ProcessPreview();

		RustAssetProcessor.OnAssetsLoaded += prefabs =>
		{
			ProcessPreview();
		};
	}
	public void ProcessPreview()
	{
		if (_instance != null || RustAssetProcessor.Prefabs == null || RustAssetProcessor.PrefabLookup == null)
		{ 
			return;
		}

		var prefab = RustAssetProcessor.PrefabLookup.backend.LoadPrefab(Path);

		if (prefab != null)
		{
			_instance = Instantiate(prefab);
			_instance.transform.SetParent(transform);
			_instance.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			_instance.SetActive(true);
		}
	}

	public void Cleanup()
	{
		if (_instance == null)
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
