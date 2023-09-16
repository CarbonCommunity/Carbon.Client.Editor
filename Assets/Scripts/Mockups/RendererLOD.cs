using UnityEngine;

public class RendererLOD : MonoBehaviour
{
	public int curlod;
	public bool force;
	public bool isSmall;
	public bool isBeingForcedOff;
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
		public bool isImpostor;
	}

}