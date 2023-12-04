using System;
using System.Collections.Generic;
using System.Linq;
using Carbon;
using Carbon.Client;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class RustAsset : MonoBehaviour
{
	public static List<RustAsset> assets = new ();

	[Header("Properties")]
	public string Path;
	public Bounds Bounds;

	[Header("Instance")]
	public RustPrefab.EntityData Entity = new();
	public RustPrefab.ModelData Model = new();

	[NonSerialized] public Vector3 Position;
	[NonSerialized] public Quaternion Rotation;
	[NonSerialized] public Vector3 Scale;

	internal GameObject _instance;
	internal Transform _center;
	internal float _timeSinceRetry;
	internal List<ColliderData> _colliders = new();

	internal static Shader _standardShader => Shader.Find("Standard");

	public struct ColliderData
	{
		public Collider collider;
		public bool WasEnabled;

		public void Disable()
		{
			collider.enabled = false;
		}
		public void Restore()
		{
			collider.enabled = WasEnabled;
		}
	}

	public void Cache()
	{
		Position = transform.position;
		Rotation = transform.rotation;
		Scale = transform.localScale;

#if UNITY_EDITOR

		if (Model.PrefabReference != null)
		{
			Model.PrefabPath = AssetDatabase.GetAssetPath(Model.PrefabReference).ToLower();
		}

#endif
	}

	public bool HasChanged(out Vector3 pos, out Quaternion rot, out Vector3 scale)
	{
		pos = transform.position;
		rot = transform.rotation;
		scale = transform.localScale;

		if (Position != pos || Rotation != rot || Scale != scale)
		{
			Position = pos;
			Rotation = rot;
			Scale = scale;
			return true;
		}

		return false;
	}

#if UNITY_EDITOR
	[ContextMenu("Draw Custom Models")]
	public void CreateCustomModelsPreview()
	{
		foreach (var model in assets)
		{
			if (model.Model.PrefabReference == null)
			{
				continue;
			}

			var newModel = Instantiate(model.Model.PrefabReference).transform;
			newModel.SetParent(model.transform, false);
			newModel.localPosition = Vector3.zero;
			newModel.localRotation = Quaternion.identity;
		}
	}
#endif

	public bool EnableColliders
	{
		set
		{
			if (_colliders == null)
			{
				return;
			}

			_colliders.RemoveAll(x => x.collider == null || x.collider.gameObject == null);

			foreach (var collider in _colliders)
			{
				if (value)
				{
					collider.Disable();
				}
				else
				{
					collider.Restore();
				}
			}
		}
	}

	public void OnDrawGizmos()
	{
		var @switch = Defines.Singleton.BoundsSwitch;

		if (!@switch.Enabled)
		{
			return;
		}

		var matrix = Gizmos.matrix;
		var color = Gizmos.color;

		Gizmos.matrix = transform.localToWorldMatrix;

		Gizmos.color = @switch.Outline;
		Gizmos.DrawWireCube(Bounds.center, Bounds.size);
		Gizmos.color = @switch.Main;
		Gizmos.DrawCube(Bounds.center, Bounds.size);

		Gizmos.matrix = matrix;
		Gizmos.color = color;
	}

	public void OnEnable()
	{
		Fetch();
	}
	public void OnDestroy()
	{
		Cleanup();

		if (assets.Contains(this))
		{
			assets.Remove(this);
		}
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

		_instance.SetActive(gameObject.activeInHierarchy);

		if (HasChanged(out var pos, out var rot, out var scale))
		{
			_instance.transform.SetPositionAndRotation(pos, rot);
			_instance.transform.localScale = scale;
		}
	}

	public void Preview()
	{
		if (Model.PrefabReference != null)
		{
			Cleanup();
			return;
		}

		try
		{
			Fetch();

			if (Defines.IsBuildingAddons || RustAssetProcessor.Prefabs == null || RustAssetProcessor.PrefabLookup == null || RustAssetProcessor.PrefabLookup.backend == null)
			{
				return;
			}

			if (RustAssetProcessor.Instance != null && !RustAssetProcessor.Instance.CreateVisuals)
			{
				return;
			}

			if (_instance != null)
			{
				return;
			}

			var prefab = RustAssetProcessor.PrefabLookup.backend.LoadPrefab(Path);
			var previewContainer = Defines.Singleton.GetPreviewContainer();

			Bounds = default;

			if (prefab != null && previewContainer != null)
			{
				_instance = Instantiate(prefab, previewContainer);
				_instance.transform.SetLocalPositionAndRotation(transform.position, transform.rotation);
				_instance.transform.localScale = transform.localScale;
				_instance.SetActive(true);
				_instance.tag = "EditorOnly";

				var colliders = _instance.transform.GetComponents<Collider>().Concat(_instance.transform.GetComponentsInChildren<Collider>());
				var renderers = _instance.transform.GetComponents<MeshRenderer>().Concat(_instance.transform.GetComponentsInChildren<MeshRenderer>());
				var skinnedRenderers = _instance.transform.GetComponents<SkinnedMeshRenderer>().Concat(_instance.transform.GetComponentsInChildren<SkinnedMeshRenderer>());

				_colliders.Clear();
				_colliders.AddRange(colliders.Select(x => new ColliderData
				{
					collider = x, WasEnabled = x.enabled
				}));

				var standard = Shader.Find("Standard");

				void ProcessShader(Material material)
				{
					switch (material.shader.name)
					{
						case "Standard":
						case "Rust/Standard":
						case "Rust/Standard Cloth":
							material.shader = standard;
							break;
					}
				}

				foreach (var renderer in renderers)
				{
					Bounds.Encapsulate(renderer.localBounds);

					foreach (var material in renderer.sharedMaterials)
					{
						ProcessShader(material);
					}
				}

				foreach (var renderer in skinnedRenderers)
				{
					Bounds.Encapsulate(renderer.localBounds);

					foreach (var material in renderer.sharedMaterials)
					{
						ProcessShader(material);
					}
				}

				Bounds.center = new Vector3(Bounds.center.x, Bounds.center.y, Bounds.center.z);

				foreach (var renderer in renderers)
				{
					foreach (var material in renderer.sharedMaterials)
					{
						if (material.name.ToLower().Contains("glass"))
						{
							material.shader = _standardShader;
						}
					}
				}

				foreach (var renderer in skinnedRenderers)
				{
					foreach (var material in renderer.sharedMaterials)
					{
						if (material.name.ToLower().Contains("glass"))
						{
							material.shader = _standardShader;
						}
					}
				}

				// var max = Bounds.max;
				// var min = Bounds.min;
				// var top = new GameObject("top").transform;
				// top.SetParent(transform, false);
				// top.localPosition = new Vector3(min.x, max.y, 0);

				// _center = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
				// _center.name = $"center";
				// _center.SetParent(transform, false);
				// _center.localScale = Vector3.zero;
				// _center.localPosition = Bounds.center * 2;
				// _center.localRotation = Quaternion.identity;
				// DestroyImmediate(_center.GetComponent<Collider>());

				// var bottom = new GameObject("bottom").transform;
				// bottom.SetParent(transform, false);
				// bottom.localPosition = new Vector3(min.x, min.y, 0);

				// var tape = bottom.gameObject.AddComponent<MeasuringTape>();
				// tape.Point = top.gameObject;
			}
		}
		catch (Exception ex)
		{
			Debug.LogError($"Failed preview for {Path} ({ex.Message})\n{ex.StackTrace}");
		}
	}
	public void Cleanup()
	{
		try
		{
			if (_instance != null)
			{
				DestroyImmediate(_instance);
				_instance = null;
			}

			_center = null;
		}
		catch { }
	}
	public void Fetch()
	{
		if (!assets.Contains(this))
		{
			assets.Add(this);
		}
	}

	public void OnSelected()
	{
		EnableColliders = false;
	}
	public void OnDeselected()
	{
		EnableColliders = true;
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
}
