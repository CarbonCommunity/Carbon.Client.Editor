using UnityEngine;

public class BurstClothHitBoxCollision : MonoBehaviour
{
	public bool UseLocalGravity;
	public float GravityStrength;
	public float DefaultLength;
	public float MountedLengthMultiplier;
	public float DuckedLengthMultiplier;
	public float CorpseLengthMultiplier;
	public bool SiblingConstraints;
	public int StiffnessDepth;
	public float LengthModifier;
	public UnityEngine.Vector3 Gravity;
	public bool EnableCollisions;
	public float CollisionRadius;
	public bool EnableSimulation;
	public int TickRate;
	public int MaxTicksPerFrame;
	public int ConstraintIterationCount;
	public UnityEngine.Vector3 _origin;
	public UnityEngine.Vector3 _up;
	public UnityEngine.Vector3 _simulationSpaceDelta;
	public UnityEngine.Vector3 _prevSimulationOrigin;
	public float _accumulator;
	public int _boneCount;
	public int _maxBoneDepth;

}