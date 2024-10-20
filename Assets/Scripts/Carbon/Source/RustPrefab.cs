using System;
using UnityEngine;

namespace Carbon.Client
{
	[Serializable]
	public partial class RustPrefab
	{
		public string rustPath;
		public string parentPath;
		public bool parent;
		public Vector3 position;
		public Vector3 rotation;
		public Vector3 scale;
		public EntityData entity;
		public ModelData model;

		[Serializable]
		public class EntityData
		{
			public bool enforcePrefab;
			public EntityFlags flags;
			public ulong skin;
			public float health = -1;
			public float maxHealth = -1;

			[Flags]
			public enum EntityFlags
			{
				Placeholder = 1,
				On = 2,
				OnFire = 4,
				Open = 8,
				Locked = 16,
				Debugging = 32,
				Disabled = 64,
				Reserved1 = 128,
				Reserved2 = 256,
				Reserved3 = 512,
				Reserved4 = 1024,
				Reserved5 = 2048,
				Broken = 4096,
				Busy = 8192,
				Reserved6 = 16384,
				Reserved7 = 32768,
				Reserved8 = 65536,
				Reserved9 = 131072,
				Reserved10 = 262144,
				Reserved11 = 524288,
				InUse = 1048576,
				Reserved12 = 2097152,
				Reserved13 = 4194304,
				Unused23 = 8388608,
				Protected = 16777216,
				Transferring = 33554432
			}
		}

		[Serializable]
		public class ModelData
		{
			#region Editor

			public GameObject prefabReference;

			#endregion

#if UNITY_EDITOR
			[HideInInspector]
#endif
			public string PrefabPath;
		}
	}
}
