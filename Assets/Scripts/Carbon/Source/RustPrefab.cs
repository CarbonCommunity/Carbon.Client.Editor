using System;
using Carbon.Client.Packets;
using ProtoBuf;
using UnityEngine;

namespace Carbon.Client
{
	[ProtoContract]
	public partial class RustPrefab
	{
		[ProtoMember(1 + Protocol.VERSION)]
		public string Path;

		[ProtoMember(2 + Protocol.VERSION)]
		public BaseVector Position;

		[ProtoMember(3 + Protocol.VERSION)]
		public BaseVector Rotation;

		[ProtoMember(4 + Protocol.VERSION)]
		public BaseVector Scale;

		[ProtoMember(5 + Protocol.VERSION)]
		public EntityData Entity;

		[ProtoMember(6 + Protocol.VERSION)]
		public ModelData Model;

		[Serializable, ProtoContract]
		public class EntityData
		{
			[ProtoMember(1 + Protocol.VERSION)]
			public bool EnforcePrefab;

			[ProtoMember(2 + Protocol.VERSION)]
			public EntityFlags Flags;

			[ProtoMember(3 + Protocol.VERSION)]
			public ulong Skin;

#if UNITY_EDITOR
			[Header("Entity Types")]
#endif

			[ProtoMember(4 + Protocol.VERSION)]
			public CombatEntity Combat;

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

			[Serializable, ProtoContract]
			public class CombatEntity
			{
				[ProtoMember(1 + Protocol.VERSION)]
				public float Health = -1;

				[ProtoMember(2 + Protocol.VERSION)]
				public float MaxHealth = -1;
			}
		}

		[Serializable, ProtoContract]
		public class ModelData
		{
			#region Editor

			public GameObject PrefabReference;

			#endregion

			#if UNITY_EDITOR
			[HideInInspector]
			#endif
			[ProtoMember(1 + Protocol.VERSION)]
			public string PrefabPath;

#if UNITY_EDITOR
			[Header("Animation")]
#endif

			[ProtoMember(2 + Protocol.VERSION)]
			public bool NetworkAnimation = true;

#if UNITY_EDITOR
			[Tooltip("When this is enabled, the server will occasionally send a network packet to synchronize the animation time, speed and clip, making sure playback is consistent.")]
#endif
			[ProtoMember(3 + Protocol.VERSION)]
			public bool SyncAnimation = false;

#if UNITY_EDITOR
			[Header("Collision")]
#endif

			[ProtoMember(4 + Protocol.VERSION)]
			public bool EntitySolidCollision = false;

			[ProtoMember(5 + Protocol.VERSION)]
			public bool EntityTriggerCollision = false;
		}
	}
}
