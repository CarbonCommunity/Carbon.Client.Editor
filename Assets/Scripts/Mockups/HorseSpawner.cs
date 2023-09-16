using UnityEngine;

public class HorseSpawner : MonoBehaviour
{
	public float respawnDelay;
	public float respawnDelayVariance;
	public bool spawnForSale;
	public float spawnNudgeRadius;
	public float cleanupRadius;
	public float occupyRadius;
	public float safeRadius;
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