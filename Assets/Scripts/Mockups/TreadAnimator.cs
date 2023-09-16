using UnityEngine;

public class TreadAnimator : MonoBehaviour
{
	public float wheelBoneDistMax;
	public float traceThickness;
	public float heightFudge;
	public bool useWheelYOrigin;
	public UnityEngine.Vector2 treadTextureDirection;
	public bool isMetallic;
	public float angularVelocity;
	public UnityEngine.Vector3 lastForward;
	public UnityEngine.Vector3 currentVelocity;
	public UnityEngine.Vector3 lastPos;
	public float angularTreadConstant;
	public float treadConstant;
	public float wheelSpinConstant;
	public float wheelAngle;
	public float treadMovementL;
	public float treadMovementR;
	public float traceLineMin;
	public float traceLineMax;
	public float maxShockDist;
	public int cachedMask;

}