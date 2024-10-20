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
	public partial class Addon : IStore<Addon, Asset>, IDisposable
	{
		public const string EXTENSION = ".cca";

		public string name;
		public string author;
		public string description;
		public string version;
		public string thumbnail;
		public string checksum;
		public Dictionary<string, Asset> assets = new Dictionary<string, Asset>();
		public long creationTime = DateTime.Now.Ticks;

		public string url;

		public bool isDirty;
		public byte[] buffer;

		public Manifest GetManifest()
		{
			MarkDirty();

			return new Manifest
			{
				info = new AddonInfo
				{
					name = name,
					author = author,
					description = description,
					version = version,
					thumbnail = thumbnail
				},
				assets = assets.Select(x => x.Value.GetManifest()).ToArray(),
				creationTime = creationTime,
				url = url,
				checksum = checksum
			};
		}

		public static Addon Create(AddonInfo info, params Asset[] assets)
		{
			var addon = new Addon
			{
				name = info.name,
				author = info.author,
				description = info.description,
				version = info.version,
				thumbnail = info.thumbnail
			};

			foreach (var asset in assets)
			{
				addon.assets.Add(asset.name, asset);
			}

			addon.MarkDirty();
			return addon;
		}
		public static Addon ImportFromFile(string path)
		{
			var data = File.ReadAllBytes(path);
			var result = Deserialize(data);

			Array.Clear(data, 0, data.Length);
			data = null;
			return result;
		}
		public static Addon Deserialize(byte[] buffer)
		{
			var addon = new Addon();

			using var memoryStream = new MemoryStream(buffer);
			using var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
			using var reader = new BinaryReader(gzipStream);

			var protocol = reader.ReadUInt32();

			if(protocol != Protocol.VERSION)
			{
				throw new Exception($"Invalid protocol: {protocol} [expected {Protocol.VERSION}]");
			}

			addon.name = reader.ReadString();
			addon.author = reader.ReadString();
			addon.description = reader.ReadString();
			addon.version = reader.ReadString();
			addon.thumbnail = reader.ReadString();
			addon.creationTime = reader.ReadInt64();

			var assetCount = reader.ReadInt32();
			for (int i = 0; i < assetCount; i++)
			{
				var asset = new Asset();
				addon.assets.Add(reader.ReadString(), asset);
				asset.name = reader.ReadString();
				asset.data = reader.ReadBytes(reader.ReadInt32());
				asset.additionalData = reader.ReadBytes(reader.ReadInt32());
			}

			addon.MarkDirty();
			return addon;
		}

		public byte[] Serialize()
		{
			using var memoryStream = new MemoryStream();
			using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
			{
				using var writer = new BinaryWriter(gzipStream);

				writer.Write(Protocol.VERSION);
				writer.Write(name);
				writer.Write(author);
				writer.Write(description);
				writer.Write(version);
				writer.Write(thumbnail);
				writer.Write(creationTime);

				var assetValues = assets.Values;

				writer.Write(assets.Count);

				foreach (var asset in assets)
				{
					writer.Write(asset.Key);
					writer.Write(asset.Value.name);
					writer.Write(asset.Value.data.Length);
					writer.Write(asset.Value.data);
					writer.Write(asset.Value.additionalData.Length);
					writer.Write(asset.Value.additionalData);
				}
			}

			return memoryStream.ToArray();
		}
		public void StoreToFile(string path)
		{
			path += EXTENSION;

			File.WriteAllBytes(path, Serialize());
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject(GetManifest(), Formatting.Indented);
		}
		public string ToName()
		{
			return $"{name} v{version} by {author}";
		}

		public void MarkDirty()
		{
			if (isDirty)
			{
				return;
			}

			if (buffer != null)
			{
				Array.Clear(buffer, 0, buffer.Length);
				buffer = null;
			}

			buffer = Serialize();
			UpdateChecksum();

			isDirty = true;
		}
		public void Dispose()
		{
			foreach (var asset in assets)
			{
				asset.Value.Dispose();
			}

			if (buffer != null)
			{
				Array.Clear(buffer, 0, buffer.Length);
				buffer = null;
			}
		}

		internal void UpdateChecksum()
		{
			using var md5 = MD5.Create();
			var bytes = md5.ComputeHash(buffer);
			var result = Convert.ToBase64String(bytes);
			Array.Clear(bytes, 0, bytes.Length);
			checksum = result;
		}

		public partial class Manifest
		{
			public AddonInfo info;
			public Asset.Manifest[] assets;
			public long creationTime;
			public string url;
			public string checksum;

			public string CreationTimeReadable => new DateTime(creationTime).ToString();
		}

		public struct AddonInfo
		{
			public string name;
			public string author;
			public string description;
			public string version;
			public string thumbnail;

			public readonly string CacheName => $"{name.Replace(" ", "_").Replace(".", "_").Replace(":", "_")}".ToLower();
		}
	}
}
