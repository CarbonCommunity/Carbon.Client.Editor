using System;
using System.Collections.Generic;
using Carbon.Extensions;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Carbon.Client
{
	public class CustomProceduralObject : MonoBehaviour
	{
		public int Seed;

		public Bounds Bounds;

		public float Spacing = 1;
		public Range<int> Width;
		public Range<int> Length;

		[Serializable]
		public struct Range<T>
		{
			public T Min;
			public T Max;

			public float PickFloat(int seed)
			{
				if (Min is float min && Max is float max)
				{
					return RandomEx.GetRandomFloat(min, max, seed);
				}

				return default;
			}
			public int PickInt(int seed)
			{
				if (Min is int min && Max is int max)
				{
					return RandomEx.GetRandomInteger(min, max, seed);
				}

				return default;
			}
		}

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

		public void Generate(int? seed = null)
		{
			if (seed != null)
			{
				Seed = seed.GetValueOrDefault();
			}

			Clear();

			var random = new System.Random(Seed);
			var width = Width.PickInt(Seed);
			var length = Length.PickInt(Seed);

			var totalSizeX = width * Spacing;
			var totalSizeZ = length * Spacing;
			var offsetX = totalSizeX / 2f;
			var offsetZ = totalSizeZ / 2f;

			for (int x = 0; x < width; x++)
			{
				for (int z = 0; z < length; z++)
				{
					var guess = (float)default;
					var entry = (CustomProceduralObjectEntry)null;

					RandomizeEntry();

					void RandomizeEntry()
					{
						guess = RandomEx.GetRandomFloat(0f, 1f, random.Next());
						entry = Entries[random.Next(0, Entries.Length)];
					}

					while (entry.Chance != 1 && entry.Chance < guess)
					{
						RandomizeEntry();
					}

					var instance = Instantiate(entry.gameObject).GetComponent<CustomProceduralObjectEntry>();
					instance.transform.SetParent(transform, false);
					instance.transform.localPosition = new Vector3((x * Spacing) - offsetX, 0, (z * Spacing) - offsetZ);

					var rotationX = instance.XRotationSteps * RandomEx.GetRandomInteger(0, 180, random.Next());
					var rotationY = instance.YRotationSteps * RandomEx.GetRandomInteger(0, 180, random.Next());
					var rotationZ = instance.ZRotationSteps * RandomEx.GetRandomInteger(0, 180, random.Next());

					instance.transform.localRotation = Quaternion.Euler(new Vector3(rotationX, rotationY, rotationZ));
					Bounds.Encapsulate(instance.Bounds);

					InstanceObjects.Add(instance);
				}
			}

			foreach (var instance in InstanceObjects)
			{
				instance.transform.localPosition -= Bounds.center;
			}
		}
		public void Clear()
		{
			Bounds = default;

			foreach (var instance in InstanceObjects)
			{
				instance.transform.SetParent(null);
				DestroyImmediate(instance.gameObject);
			}

			InstanceObjects.Clear();
		}
	}

	#if UNITY_EDITOR

	[CustomEditor(typeof(CustomProceduralObject), true)]
	public class CustomProceduralObjectEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			var procedural = (CustomProceduralObject)target;

			if (GUILayout.Button("Randomize Seed"))
			{
				procedural.Seed = RandomEx.GetRandomInteger();
			}

			GUILayout.BeginHorizontal();
			{
				if (GUILayout.Button("Generate"))
				{
					procedural.Generate();
				}

				if (GUILayout.Button("Clear"))
				{
					procedural.Clear();
				}
			}
			GUILayout.EndHorizontal();

			if (GUILayout.Button("Randomize Seed + Generate"))
			{
				procedural.Seed = RandomEx.GetRandomInteger();
				procedural.Generate();
			}
		}
	}

	#endif
}
