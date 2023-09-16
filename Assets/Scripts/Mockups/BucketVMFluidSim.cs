using UnityEngine;

public class BucketVMFluidSim : MonoBehaviour
{
	public float waterLevel;
	public float targetWaterLevel;
	public float PlayerEyePitch;
	public float turb_forward;
	public float turb_side;
	public UnityEngine.Vector3 lastPosition;
	public UnityEngine.Vector3 groundSpeedLast;
	public UnityEngine.Vector3 lastAngle;
	public UnityEngine.Vector3 vecAngleSpeedLast;
	public UnityEngine.Vector3 initialPosition;

}