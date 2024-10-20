using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using UnityEngine;

namespace Carbon.Client
{
	public partial class RustBundle
	{
		public Dictionary<string, List<RustPrefab>> rustPrefabs = new Dictionary<string, List<RustPrefab>>();
		public Dictionary<string, List<RustComponent>> components = new Dictionary<string, List<RustComponent>>();

		public byte[] Serialize()
		{
			using var memoryStream = new MemoryStream();
			using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
			{
				using var writer = new BinaryWriter(gzipStream);

				writer.Write(rustPrefabs.Count);
				foreach (var prefab in rustPrefabs)
				{
					writer.Write(prefab.Key);
					writer.Write(prefab.Value.Count);

					foreach (var value in prefab.Value)
					{
						writer.Write(value.rustPath);
						writer.Write(value.parentPath);
						writer.Write(value.parent);
						writer.Write(value.position.x);
						writer.Write(value.position.y);
						writer.Write(value.position.z);
						writer.Write(value.rotation.x);
						writer.Write(value.rotation.y);
						writer.Write(value.rotation.z);
						writer.Write(value.scale.x);
						writer.Write(value.scale.y);
						writer.Write(value.scale.z);

						writer.Write(value.entity.enforcePrefab);
						writer.Write((int)value.entity.flags);
						writer.Write(value.entity.skin);
						writer.Write(value.entity.health);
						writer.Write(value.entity.maxHealth);
						writer.Write(value.model.PrefabPath);
					}
				}

				writer.Write(components.Count);
				foreach (var component in components)
				{
					writer.Write(component.Key);
					writer.Write(component.Value.Count);

					foreach (var value in component.Value)
					{
						writer.Write((int)value.Server);
						writer.Write((int)value.Client);
						writer.Write(value.Component.CreateOn.Client);
						writer.Write(value.Component.CreateOn.Server);
						writer.Write(value.Component.Type);
						writer.Write(value.Component.Members.Length);
						foreach (var member in value.Component.Members)
						{
							writer.Write(member.Name);
							writer.Write(member.Value);
						}
						writer.Write(value.Behavior.AutoDisableTimer);
						writer.Write(value.Behavior.AutoDestroyTimer);
					}
				}
			}

			return memoryStream.ToArray();
		}

		public static RustBundle Deserialize(byte[] buffer)
		{
			var bundle = new RustBundle();

			using var memoryStream = new MemoryStream(buffer);
			using var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
			using var reader = new BinaryReader(gzipStream);

			var rustPrefabCount = reader.ReadInt32();
			for (int i = 0; i < rustPrefabCount; i++)
			{
				var list = new List<RustPrefab>();
				bundle.rustPrefabs.Add(reader.ReadString(), list);

				var listCount = reader.ReadInt32();
				for (int y = 0; y < listCount; y++)
				{
					var prefab = new RustPrefab();
					prefab.rustPath = reader.ReadString();
					prefab.parentPath = reader.ReadString();
					prefab.parent = reader.ReadBoolean();
					prefab.position = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
					prefab.rotation = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
					prefab.scale = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
					prefab.entity = new();
					prefab.entity.enforcePrefab = reader.ReadBoolean();
					prefab.entity.flags = (RustPrefab.EntityData.EntityFlags)reader.ReadInt32();
					prefab.entity.skin = reader.ReadUInt64();
					prefab.entity.health = reader.ReadSingle();
					prefab.entity.maxHealth = reader.ReadSingle();
					prefab.model = new();
					prefab.model.PrefabPath = reader.ReadString();
					list.Add(prefab);
				}
			}

			var componentCount = reader.ReadInt32();
			for (int i = 0; i < componentCount; i++)
			{
				var list = new List<RustComponent>();
				bundle.components.Add(reader.ReadString(), list);

				var listCount = reader.ReadInt32();
				for (int j = 0; j < listCount; j++)
				{
					var component = new RustComponent();
					component.Client = (RustComponent.PostProcessMode)reader.ReadInt32();
					component.Server = (RustComponent.PostProcessMode)reader.ReadInt32();
					component.Component.CreateOn.Client = reader.ReadBoolean();
					component.Component.CreateOn.Server = reader.ReadBoolean();
					component.Component.Type = reader.ReadString();
					component.Component.Members = new RustComponent.Member[reader.ReadInt32()];
					for (int k = 0; k < component.Component.Members.Length; k++)
					{
						var member = component.Component.Members[k] = new();
						member.Name = reader.ReadString();
						member.Value = reader.ReadString();
					}
					component.Behavior.AutoDisableTimer = reader.ReadSingle();
					component.Behavior.AutoDestroyTimer = reader.ReadSingle();
					list.Add(component);
				}
			}

			return bundle;
		}
	}
}
