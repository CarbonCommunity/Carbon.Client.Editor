using UnityEngine;

public class TorpedoServerProjectile : MonoBehaviour
{
	public float minWaterDepth;
	public float shallowWaterInaccuracy;
	public float deepWaterInaccuracy;
	public float shallowWaterCutoff;
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