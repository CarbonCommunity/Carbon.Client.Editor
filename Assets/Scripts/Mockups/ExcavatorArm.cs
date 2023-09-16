using UnityEngine;

public class ExcavatorArm : MonoBehaviour
{
	public float yaw1;
	public float yaw2;
	public float wheelSpeed;
	public float turnSpeed;
	public float beltSpeedMax;
	public float resourceProductionTickRate;
	public float timeForFullResources;
	public float wheelRotation;
	public float nextBounceTime;
	public float currentWheelTurnSpeed;
	public float currentBeltSpeed;
	public float currentBeltOffset;
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

}