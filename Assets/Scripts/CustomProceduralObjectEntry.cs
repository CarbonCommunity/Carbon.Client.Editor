using System;
using UnityEngine;

public class CustomProceduralObjectEntry : MonoBehaviour
{
	[Header("Position")]
	public bool XPosition;
	public bool YPosition;
	public bool ZPosition;

	public Dimensions Rotation;

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

	[Flags]
	public enum Dimensions
	{
		X = 1,
		Y = 2,
		Z = 3
	}
}
