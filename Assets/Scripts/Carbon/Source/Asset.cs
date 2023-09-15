/*
 *
 * Copyright (c) 2022-2023 Carbon Community 
 * All rights reserved.
 *
 */

/*
 * 
 *  DO NOT TOUCH UP THIS FILE
 *  
 */

using Newtonsoft.Json;
using ProtoBuf;

namespace Carbon.Client.Assets
{
	[ProtoContract(InferTagFromName = true)]
	public partial class Asset
	{
		[ProtoMember(1)]
		public string Name { get; set; }

		[ProtoMember(2)]
		public byte[] Data { get; set; }

		[ProtoMember(3)]
		public byte[] AdditionalData { get; set; }

		public Manifest GetManifest()
		{
			return new Manifest
			{
				Name = Name,
				BufferLength = Data.Length,
			};
		}

		public UnityEngine.AssetBundle CachedBundle { get; set; }

		public bool IsUnpacked => CachedBundle != null;

		public static Asset CreateFrom(string name, byte[] data)
		{
			return new Asset
			{
				Name = name,
				Data = data
			};
		}
		public static Asset CreateFromFile(string path)
		{
			return CreateFrom(System.IO.Path.GetFileNameWithoutExtension(path), System.IO.File.ReadAllBytes(path));
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject(GetManifest(), Formatting.Indented);
		}

		public void ClearData()
		{
			if (Data != null)
			{
				System.Array.Clear(Data, 0, Data.Length);
				Data = null;
			}
		}

		public void Dispose()
		{
			if (!IsUnpacked)
			{
				return;
			}

			CachedBundle.Unload(true);

			ClearData();
		}

		public class Manifest
		{
			public string Name { get; set; }
			public int BufferLength { get; set; }
		}
	}
}
