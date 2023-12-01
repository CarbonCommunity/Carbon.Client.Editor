using System;
using System.Collections.Generic;
using UnityEngine;

namespace Carbon.Client
{
	public class CustomProceduralObject : MonoBehaviour
	{
		public int Seed;
		public Bounds Bounds;

		[Header("References")]
		public CustomProceduralObjectEntry[] Entries;

		[Header("Debugging")]
		public List<CustomProceduralObjectEntry> InstanceObjects;

		public void Start()
		{
			Generate();
		}

		public void OnDrawGizmos()
		{
			var @switch = Defines.Singleton.BoundsSwitch;

			if (!@switch.Enabled)
			{
				return;
			}

			var matrix = Gizmos.matrix;
			var color = Gizmos.color;

			Gizmos.matrix = transform.localToWorldMatrix;

			Gizmos.color = @switch.Outline;
			Gizmos.DrawWireCube(Bounds.center, Bounds.size);
			Gizmos.color = @switch.Main;
			Gizmos.DrawCube(Bounds.center, Bounds.size);

			Gizmos.matrix = matrix;
			Gizmos.color = color;
		}

		public void Generate()
		{
			Clear();

			var dimensionType = typeof(CustomProceduralObjectEntry.Dimensions);
			var random = new System.Random(Seed);
			var dimensions = Enum.GetNames(dimensionType);
			var previousEntry = (CustomProceduralObjectEntry)null;

			while (InstanceObjects.Count <= 10)
			{
				var entry = Entries[random.Next(0, Entries.Length)];
				var instance = Instantiate(entry.gameObject).GetComponent<CustomProceduralObjectEntry>();
				var dimension = (CustomProceduralObjectEntry.Dimensions)default;

				if (entry.XPosition || entry.YPosition || entry.ZPosition)
				{
					while((dimension == CustomProceduralObjectEntry.Dimensions.X && !entry.XPosition) ||
						(dimension == CustomProceduralObjectEntry.Dimensions.Y && !entry.YPosition) ||
						(dimension == CustomProceduralObjectEntry.Dimensions.Z && !entry.ZPosition))
					{
						dimension = (CustomProceduralObjectEntry.Dimensions)Enum.Parse(dimensionType, dimensions[random.Next(0, dimensions.Length)]);
					}
				}

				instance.transform.SetParent(transform, false);

				if (previousEntry != null)
				{
					instance.transform.position = previousEntry.transform.position;
				}

				InstanceObjects.Add(instance);

				switch (dimension)
				{
					case CustomProceduralObjectEntry.Dimensions.X:
					{
						if (previousEntry != null)
						{
							instance.transform.position += new Vector3(instance.Bounds.center.x + previousEntry.Bounds.center.x, 0, 0);
						}
						break;
					}

					case CustomProceduralObjectEntry.Dimensions.Y:
					{
						if (previousEntry != null)
						{
							instance.transform.position += new Vector3(0, instance.Bounds.center.y + previousEntry.Bounds.center.y, 0);
						}
						break;
					}

					case CustomProceduralObjectEntry.Dimensions.Z:
					{
						if (previousEntry != null)
						{
							instance.transform.position += new Vector3(0, 0, instance.Bounds.center.z + previousEntry.Bounds.center.z);
						}
						break;
					}
				}

				previousEntry = entry;
			}
		}
		public void Clear()
		{
			foreach (var instance in InstanceObjects)
			{
				Destroy(instance.gameObject);
			}

			InstanceObjects.Clear();
		}
	}
}
