using UnityEngine;

public class LODMasterMesh : MonoBehaviour
{
	public float Distance;
	public bool Block;
	public UnityEngine.Bounds MeshBounds;
	public int curlod;
	public bool force;
	public bool showState;
	public bool culled;
	public bool forceDynamic;
	public float currentDistance;
	public bool occludeeCulled;
	public bool occludeeShadowsVisible;
	public float occludeeShadowRange;
	public bool IsDynamic;
	public float CurrentDistance;

	public class LODEnableQueue : MonoBehaviour
	{
		public bool TargetState;
		public long warnTime;
		public long totalProcessed;
		public int queueProcessedLast;
		public int hashsetMaxLength;
		public int queueLength;
	}

}