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

		public GameObject _instance;
	}
}
