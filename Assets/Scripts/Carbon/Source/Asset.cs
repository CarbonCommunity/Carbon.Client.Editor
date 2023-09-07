/*
 *
 * Copyright (c) 2022-2023 Carbon Community 
 * All rights reserved.
 *
 */

using System;
using System.IO;
using Newtonsoft.Json;
using ProtoBuf;

namespace Carbon.Client.Assets
{
	[ProtoContract(InferTagFromName = true)]
	public class Asset : IDisposable
	{
		[ProtoMember(1)]
		public string Name { get; set; }

		[ProtoMember(2)]
		public byte[] Data { get; set; }

		public Manifest GetManifest()
		{
			return new Manifest
			{
				Name = Name,
				BufferLength = Data.Length,
			};
		}

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
			return CreateFrom(Path.GetFileNameWithoutExtension(path), File.ReadAllBytes(path));
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject(GetManifest(), Formatting.Indented);
		}

		public void Dispose()
		{
			if (Data != null)
			{
				Array.Clear(Data, 0, Data.Length);
				Data = null;
			}
		}

		public class Manifest
		{
			public string Name { get; set; }
			public int BufferLength { get; set; }
		}
	}
}
