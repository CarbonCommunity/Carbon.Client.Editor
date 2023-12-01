using System;
using UnityEngine;

namespace Carbon.Client
{
	public class CustomProceduralObjectEntry : MonoBehaviour
	{
		[Range(0f, 1f)]
		public float Chance = 1f;

		[Header("Rotation")]
		public float XRotationSteps;
		public float YRotationSteps;
		public float ZRotationSteps;

		public Bounds Bounds;

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
	}
}
