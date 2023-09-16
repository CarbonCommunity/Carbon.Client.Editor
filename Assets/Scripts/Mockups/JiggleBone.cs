using UnityEngine;

public class JiggleBone : MonoBehaviour
{
	public bool debugMode;
	public UnityEngine.Vector3 targetPos;
	public UnityEngine.Vector3 dynamicPos;
	public UnityEngine.Vector3 boneAxis;
	public float targetDistance;
	public float bStiffness;
	public float bMass;
	public float bDamping;
	public float bGravity;
	public UnityEngine.Vector3 force;
	public UnityEngine.Vector3 acc;
	public UnityEngine.Vector3 vel;
	public bool SquashAndStretch;
	public float sideStretch;
	public float frontStretch;
	public float disableDistance;
	public bool disabled;

}