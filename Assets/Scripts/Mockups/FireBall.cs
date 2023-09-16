using UnityEngine;

public class FireBall : MonoBehaviour
{
	public float lifeTimeMin;
	public float lifeTimeMax;
	public float generation;
	public float tickRate;
	public float damagePerSecond;
	public float radius;
	public int waterToExtinguish;
	public bool canMerge;
	public bool ignoreNPC;
	public bool wasResting;
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