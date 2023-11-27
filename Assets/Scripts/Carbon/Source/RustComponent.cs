using System;
using ProtoBuf;
using UnityEngine;

namespace Carbon.Client
{
	[ProtoContract]
	public partial class RustComponent : MonoBehaviour
	{
		[ProtoMember(1 + Protocol.VERSION)]
		public PostProcessMode Server = PostProcessMode.Active;

		[ProtoMember(2 + Protocol.VERSION)]
		public PostProcessMode Client = PostProcessMode.Active;

		[ProtoMember(3 + Protocol.VERSION)]
		public ComponentInfo Component = new ComponentInfo();

		public enum PostProcessMode
		{
			Active,
			Disabled,
			Destroyed
		}

		[Serializable, ProtoContract]
		public class Member
		{
			[ProtoMember(1 + Protocol.VERSION)]
			public string Name;

			[ProtoMember(2 + Protocol.VERSION)]
			public string Value;
		}

		[Serializable, ProtoContract]
		public class Platform
		{
			[ProtoMember(1 + Protocol.VERSION)]
			public bool Server;

			[ProtoMember(2 + Protocol.VERSION)]
			public bool Client;
		}

		[Serializable, ProtoContract]
		public class ComponentInfo
		{
			[ProtoMember(1 + Protocol.VERSION)]
			public Platform CreateOn = new Platform();

			[ProtoMember(2 + Protocol.VERSION)]
			public string Type;

			[ProtoMember(3 + Protocol.VERSION)]
			public Member[] Members;
		}
	}
}
