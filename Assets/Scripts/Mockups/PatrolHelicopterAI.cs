using UnityEngine;

public class PatrolHelicopterAI : MonoBehaviour
{
	public UnityEngine.Vector3 interestZoneOrigin;
	public UnityEngine.Vector3 destination;
	public bool hasInterestZone;
	public float moveSpeed;
	public float maxSpeed;
	public float courseAdjustLerpTime;
	public UnityEngine.Vector3 windVec;
	public UnityEngine.Vector3 targetWindVec;
	public float windForce;
	public float windFrequency;
	public float targetThrottleSpeed;
	public float throttleSpeed;
	public float maxRotationSpeed;
	public float rotationSpeed;
	public float terrainPushForce;
	public float obstaclePushForce;
	public float oceanDepthTargetCutoff;
	public float arrivalTime;

	public class targetinfo : MonoBehaviour
	{
		public float lastSeenTime;
		public float visibleFor;
		public float nextLOSCheck;
	}

	public class aiState : MonoBehaviour
	{
	}

}