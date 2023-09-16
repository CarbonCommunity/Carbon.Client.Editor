using UnityEngine;

public class SeekingServerProjectile : MonoBehaviour
{
	public float courseAdjustRate;
	public float maxTrackDistance;
	public float minLockDot;
	public float flareLockDot;
	public bool autoSeek;
	public float swimAfter;
	public float launchingDuration;
	public float armingDuration;
	public float velocityRampUpTime;
	public UnityEngine.Vector3 armingFinalDir;
	public float armingVelocity;
	public float orphanedVectorChangeRate;
	public float totalArmingPhaseDuration;
	public UnityEngine.Vector3 initialVelocity;
	public float drag;
	public float gravityModifier;
	public float speed;
	public float scanRange;
	public UnityEngine.Vector3 swimScale;
	public UnityEngine.Vector3 swimSpeed;
	public float radius;
	public bool HasRangeLimit;

}