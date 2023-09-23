using System;
using Carbon.Client.Packets;
using ProtoBuf;
using UnityEngine;

namespace Carbon.Client
{
	[ProtoContract]
	public partial class RustPrefab : MonoBehaviour
	{
		[ProtoMember(1)]
		public string Path;

		[ProtoMember(2)]
		public BaseVector Position;

		[ProtoMember(3)]
		public BaseVector Rotation;

		[ProtoMember(4)]
		public BaseVector Scale;

		[ProtoMember(5)]
		public EntityData Entity;

		[Serializable, ProtoContract]
		public class EntityData
		{
			[ProtoMember(1)]
			public EntityFlags Flags;

			[ProtoMember(2)]
			public bool EnforcePrefab;

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
	}
}
