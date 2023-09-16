using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ProtoBuf;
using UnityEngine;

namespace Carbon.Client
{
	[ProtoContract]
	public class RustBundle
	{
		[ProtoMember(1)]
		public Dictionary<string, List<RustComponent>> Components = new Dictionary<string, List<RustComponent>>();
	}
}
