using UnityEngine;

public class ParticleSystemLOD : MonoBehaviour
{
	public bool playOnShow;
	public float maxEmission;
	public int curlod;
	public bool force;
	public bool initialized;
	public bool culled;
	public bool forceDynamic;
	public float currentDistance;
	public bool occludeeCulled;
	public bool occludeeShadowsVisible;
	public float occludeeShadowRange;
	public bool IsDynamic;
	public float CurrentDistance;

	public class State : MonoBehaviour
	{
		public float distance;
		public float emission;
	}

}