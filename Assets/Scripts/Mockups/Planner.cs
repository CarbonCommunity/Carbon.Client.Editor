using UnityEngine;

public class Planner : MonoBehaviour
{
	public UnityEngine.Vector3 rotationOffset;
	public bool hasAppliedStartingRotation;
	public bool isTypeDeployable;
	public bool isDeployed;
	public float nextExamineTime;
	public bool isBuildingTool;
	public float hostileScore;
	public UnityEngine.Vector3 FirstPersonArmOffset;
	public UnityEngine.Vector3 FirstPersonArmRotation;
	public float FirstPersonRotationStrength;
	public UnityEngine.Vector3 punchAdded;
	public float lastPunchTime;
	public bool hostile;
	public UnityEngine.Bounds bounds;
	public bool enableSaving;
	public bool syncPosition;
	public uint parentBone;
	public ulong skinID;
	public bool HasBrain;
	public uint broadcastProtocol;
	public bool linkedToNeighbours;
	public bool isVisible;
	public bool isAnimatorVisible;
	public bool isShadowVisible;
	public float RealisticMass;
	public bool IsNpc;
	public bool HasDisabledRenderers;
	public uint prefabID;
	public bool globalBroadcast;
	public bool globalBuildingBlock;
	public bool canTriggerParent;
	public bool isServer;
	public bool isClient;

	public class Guide : MonoBehaviour
	{
		public bool wasTransparent;
	}

}