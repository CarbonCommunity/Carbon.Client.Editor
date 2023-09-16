using System.Collections.Generic;
using Carbon;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteAlways]
public class RustAsset : MonoBehaviour
{
	public static List<RustAsset> assets = new ();

	public string Path;

	internal GameObject _instance;
	internal float _timeSinceRetry;

	internal Vector3 _pos;
	internal Quaternion _rot;
	internal Vector3 _scale;

	public bool HasChanged(out Vector3 pos, out Quaternion rot, out Vector3 scale)
	{
		pos = transform.position;
		rot = transform.rotation;
		scale = transform.localScale;

		if (_pos != pos || _rot != rot || _scale != scale)
		{
			_pos = pos;
			_rot = rot;
			_scale = scale;
			return true;
		}

		return false;
	}

	public void Awake()
	{
		Fetch();
		Preview();
	}
	public void Tick()
	{
		if (_instance == null)
		{
			return;
		}

		if (HasChanged(out var pos, out var rot, out var scale) && _instance != null)
		{
			_instance.transform.SetPositionAndRotation(pos, rot);
			_instance.transform.localScale = scale;
		}
	}

	public void Preview()
	{
		Fetch();

		if (Defines.IsBuildingAddons || RustAssetProcessor.Prefabs == null || RustAssetProcessor.PrefabLookup == null)
		{ 
			return;
		}

		if(RustAssetProcessor.Instance != null && !RustAssetProcessor.Instance.CreateVisuals)
		{
			return;
		}

		Cleanup(); 

		var prefab = RustAssetProcessor.PrefabLookup.backend.LoadPrefab(Path);

		if (prefab != null)
		{
			_instance = Instantiate(prefab);
			_instance.transform.SetParent(Defines.Singleton.PreviewHub);
			_instance.transform.SetLocalPositionAndRotation(transform.position, transform.rotation);
			_instance.transform.localScale = transform.localScale;
			_instance.SetActive(true);
			_instance.tag = "EditorOnly";
		}
	}
	public void Cleanup()
	{
		if(_instance != null)
		{
			DestroyImmediate(_instance);
			_instance = null;
		}

		foreach (Transform child in transform)
		{
			DestroyImmediate(child.gameObject);
		}
	} 
	public void Fetch()
	{
		if (!assets.Contains(this))
		{
			assets.Add(this);
		}
	}

	public static void Scan(bool cleanup = false)
	{
		assets.Clear();
		assets.AddRange(FindObjectsOfType<RustAsset>());

		if (cleanup)
		{
			foreach (var asset in assets)
			{
				asset.Cleanup();
			}
		}
	}
	public static void PreviewAll()
	{
		foreach(var asset in assets)
		{
			asset.Preview();
		}
	}

	public void OnGUI()
	{

	}
}
