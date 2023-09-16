using UnityEngine;

public class LODComponent : MonoBehaviour
{
	public bool culled;
	public bool forceDynamic;
	public float currentDistance;
	public bool occludeeCulled;
	public bool occludeeShadowsVisible;
	public float occludeeShadowRange;
	public bool IsDynamic;
	public float CurrentDistance;

	public class OccludeeParameters : MonoBehaviour
	{
	}

}