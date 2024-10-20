/*
 *
 * Copyright (c) 2022-2024 Carbon Community
 * All rights reserved.
 *
 */

/*
 *
 *  DO NOT TOUCH UP THIS FILE
 *
 */

using Newtonsoft.Json;

namespace Carbon.Client.Assets
{
	public partial class Asset
	{
		public string name;
		public byte[] data;
		public byte[] additionalData;

		public Manifest GetManifest()
		{
			return new Manifest
			{
				name = name,
				bufferLength = data.Length,
			};
		}

		public RustBundle cachedRustBundle;
		public UnityEngine.AssetBundle cachedBundle;

		public bool isUnpacked => cachedBundle != null;

		public static Asset CreateFrom(string name, byte[] data)
		{
			return new Asset
			{
				name = name,
				data = data
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
			if (data != null)
			{
				System.Array.Clear(data, 0, data.Length);
				data = null;
			}
		}

		public void Dispose()
		{
			if (!isUnpacked)
			{
				return;
			}

			cachedBundle.Unload(true);
		}

		public class Manifest
		{
			public string name;
			public int bufferLength;
		}
	}
}
