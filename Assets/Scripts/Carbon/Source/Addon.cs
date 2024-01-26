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

using System.Collections.Generic;
using System.IO;
using System;
using System.IO.Compression;
using System.Security.Cryptography;
using Newtonsoft.Json;
using ProtoBuf;
using System.Linq;

namespace Carbon.Client.Assets
{
	[ProtoContract]
	public partial class Addon : IStore<Addon, Asset>, IDisposable
	{
		public const string EXTENSION = ".cca";

		[ProtoMember(1 + Protocol.VERSION)]
		public string Name { get; set; }

		[ProtoMember(2 + Protocol.VERSION)]
		public string Author { get; set; }

		[ProtoMember(3 + Protocol.VERSION)]
		public string Description { get; set; }

		[ProtoMember(4 + Protocol.VERSION)]
		public string Version { get; set; }

		[ProtoMember(5 + Protocol.VERSION)]
		public string Thumbnail { get; set; }

		[ProtoMember(6 + Protocol.VERSION)]
		public string Checksum { get; set; }

		[ProtoMember(7 + Protocol.VERSION)]
		public Dictionary<string, Asset> Assets { get; set; } = new Dictionary<string, Asset>();

		[ProtoMember(8 + Protocol.VERSION)]
		public long CreationTime { get; set; } = DateTime.Now.Ticks;

		public string Url { get; set; }

		public bool IsDirty { get; set; }
		public byte[] Buffer { get; set; }

		public Manifest GetManifest()
		{
			MarkDirty();

			return new Manifest
			{
				Info = new AddonInfo
				{
					Name = Name,
					Author = Author,
					Description = Description,
					Version = Version,
					Thumbnail = Thumbnail
				},
				Assets = Assets.Select(x => x.Value.GetManifest()).ToArray(),
				CreationTime = CreationTime,
				Url = Url,
				Checksum = GetChecksum()
			};
		}

		public static byte[] Compress(byte[] buffer)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress);
			gzipStream.Write(buffer, 0, buffer.Length);
			gzipStream.Close();
			return memoryStream.ToArray();
		}

		public static byte[] Decompress(byte[] buffer)
		{
			using MemoryStream memoryStream = new MemoryStream(buffer);
			using GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
			using MemoryStream decompressedStream = new MemoryStream();
			gzipStream.CopyTo(decompressedStream);
			return decompressedStream.ToArray();
		}

		public static Addon Create(AddonInfo info, params Asset[] assets)
		{
			var addon = new Addon
			{
				Name = info.Name,
				Author = info.Author,
				Description = info.Description,
				Version = info.Version,
			};

			foreach (var asset in assets)
			{
				addon.Assets.Add(asset.Name, asset);
			}

			addon.MarkDirty();
			addon.Checksum = addon.GetChecksum();

			return addon;
		}
		public static Addon ImportFromBuffer(byte[] buffer)
		{
			buffer = Decompress(buffer);

			var addon = Serializer.Deserialize<Addon>(new ReadOnlySpan<byte>(buffer, 0, buffer.Length));
			addon.MarkDirty();
			return addon;
		}

		public static Addon ImportFromFile(string path)
		{
			var data = File.ReadAllBytes(path);
			data = Decompress(data);

			var result = ImportFromBuffer(data);
			Array.Clear(data, 0, data.Length);
			data = null;
			return result;
		}

		public byte[] Store()
		{
			using var stream = new MemoryStream();
			Serializer.Serialize(stream, this);
			return Compress(stream.ToArray());
		}
		public void StoreToFile(string path)
		{
			path += EXTENSION;

			File.WriteAllBytes(path, Store());
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject(GetManifest(), Formatting.Indented);
		}
		public string ToName()
		{
			return $"{Name} v{Version} by {Author}";
		}

		public void MarkDirty()
		{
			if (IsDirty)
			{
				return;
			}

			if (Buffer != null)
			{
				Array.Clear(Buffer, 0, Buffer.Length);
				Buffer = null;
			}

			Buffer = Store();

			IsDirty = true;
		}
		public void Dispose()
		{
			foreach (var asset in Assets)
			{
				asset.Value.Dispose();
			}

			if (Buffer != null)
			{
				Array.Clear(Buffer, 0, Buffer.Length);
				Buffer = null;
			}
		}
		public string GetChecksum()
		{
			using (var md5 = MD5.Create())
			{
				var bytes = md5.ComputeHash(Buffer);
				var result = Convert.ToBase64String(bytes);
				Array.Clear(bytes, 0, bytes.Length);
				return result;
			}
		}

		[ProtoContract]
		public class Manifest
		{
			[ProtoMember(1)]
			public AddonInfo Info { get; set; }

			[ProtoMember(2)]
			public Asset.Manifest[] Assets { get; set; }

			[ProtoMember(3)]
			public long CreationTime { get; set; }

			[ProtoMember(4)]
			public string Url { get; set; }

			[ProtoMember(5)]
			public string Checksum { get; set; }

			public string CreationTimeReadable => new DateTime(CreationTime).ToString();
		}

		[ProtoContract]
		public struct AddonInfo
		{
			[ProtoMember(1)]
			public string Name;

			[ProtoMember(2)]
			public string Author;

			[ProtoMember(3)]
			public string Description;

			[ProtoMember(4)]
			public string Version;

			[ProtoMember(5)]
			public string Thumbnail;

			public string CacheName => $"{Name.Replace(" ", "_").Replace(".", "_")}".ToLower();
		}
	}
}
