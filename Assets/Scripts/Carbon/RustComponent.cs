using System;
using Newtonsoft.Json;
using ProtoBuf;
using UnityEngine;

namespace Carbon.Client
{
	[ProtoContract]
	public class RustComponent : MonoBehaviour
	{
		[ProtoMember(1)]
		public bool IsServer;

		[ProtoMember(2)]
		public bool IsClient;

		[ProtoMember(3)]
		public string TargetType;

		[ProtoMember(4)]
		public Member[] Members;

		[Serializable, ProtoContract]
		public class Member
		{
			[ProtoMember(1)]
			public string Name;

			[ProtoMember(2)]
			public string Value;
		}
	}
}
