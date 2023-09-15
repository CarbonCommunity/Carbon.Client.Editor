using System;
using ProtoBuf;
using UnityEngine;

namespace Carbon.Client
{
	[ProtoContract]
	public partial class RustComponent : MonoBehaviour
	{
		[ProtoMember(1)]
		public Controls DisableObjectOn = new Controls();

		[ProtoMember(2)]
		public Controls DestroyObjectOn = new Controls();

		[ProtoMember(3)]
		public ComponentInfo Component = new ComponentInfo();

		[Serializable, ProtoContract]
		public class Member
		{
			[ProtoMember(1)]
			public string Name;

			[ProtoMember(2)]
			public string Value;
		}

		[Serializable, ProtoContract]
		public class Controls
		{
			[ProtoMember(1)]
			public bool Server;

			[ProtoMember(2)]
			public bool Client;
		}

		[Serializable, ProtoContract]
		public class ComponentInfo
		{
			[ProtoMember(1)]
			public Controls CreateOn = new Controls();

			[ProtoMember(1)]
			public string Type;

			[ProtoMember(2)]
			public Member[] Members;
		}
	}
}
