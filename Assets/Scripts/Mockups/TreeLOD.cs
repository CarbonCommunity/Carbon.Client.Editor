using UnityEngine;

public class TreeLOD : MonoBehaviour
{
	public int requestedlod;
	public int curlod;
	public bool force;
	public int CulledLOD;
	public int BillboardLOD;
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