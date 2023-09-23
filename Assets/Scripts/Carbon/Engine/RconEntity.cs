using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Carbon.Client;
using Carbon.Client.Packets;
using Newtonsoft.Json;
using UnityEngine;

namespace Carbon
{
	[JsonObject(MemberSerialization.OptIn)]
    public class RconEntity : MonoBehaviour
    {
		public static Dictionary<ulong, RconEntity> entities = new();

		public GameObject Instance;

		public EntityData Data = new();

		[Serializable]
		public class EntityData
		{
			[Header("Info")]
			public ulong Id;
			public string Path;

			[Header("Identity")]
			public BaseVector Position;
			public BaseVector Rotation;
		}

		public static void ClearAll()
		{
			var pool = entities.Values;

			foreach (var entity in pool)
			{
				try
				{
					GameObject.Destroy(entity);
				}
				catch { }

				try
				{
					GameObject.DestroyImmediate(entity);
				}
				catch { }
			}
		}
		public static void CreateOrUpdate(EntityData entity)
		{
			if (!entities.TryGetValue(entity.Id, out var instance))
			{
				entities.Add(entity.Id, instance = GameObject.Instantiate(Defines.Singleton.RconEntityTemplate, Defines.Singleton.RconEntityContainer).GetComponent<RconEntity>());
				instance.Data = entity;
				instance.Create();
			}

			instance.Data.Position = entity.Position;
			instance.Data.Rotation = entity.Rotation;

			instance.DoUpdate();
		}

		public void OnDestroy()
		{
			entities.Remove(Data.Id);
		}

		public void DoUpdate()
		{
			try
			{
				transform.position = Data.Position.ToVector3();
				transform.rotation = Data.Rotation.ToQuaternion();
			}
			catch
			{
				OnDestroy();
			}
		}

		public void Create()
		{
			if (Instance != null)
			{
				return;
			}

			var prefab = RustAssetProcessor.PrefabLookup.backend.LoadPrefab(Data.Path);

			if (prefab != null)
			{
				Instance = Instantiate(prefab);
				Instance.transform.SetParent(transform);
				Instance.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				Instance.transform.localScale = transform.localScale;
				Instance.SetActive(true);
				Instance.tag = "EditorOnly";
			}
		}
		public void Cleanup()
		{
			if (Instance == null)
			{
				return;
			}

			try
			{
				Destroy(Instance);
			}
			catch { }

			try
			{
				DestroyImmediate(Instance);
			}
			catch { }

			Instance = null;
		}
    }
}
