using UnityEngine;

public class SoundSource : MonoBehaviour
{
	public bool handleOcclusionChecks;
	public bool isOccluded;
	public float occlusionAmount;
	public float lodDistance;
	public bool inRange;
	public bool wasInRange;
	public float lastOcclusionCheck;
	public float occlusionCheckInterval;
	public int lastOcclusionPointIdx;

	public class OcclusionPoint : MonoBehaviour
	{
		public UnityEngine.Vector3 offset;
		public bool isOccluded;
	}

}