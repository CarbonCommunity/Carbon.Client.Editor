using UnityEngine;

public class ProjectileWeaponMod : MonoBehaviour
{
	public bool isSilencer;
	public bool isLight;
	public bool isMuzzleBrake;
	public bool isMuzzleBoost;
	public bool isScope;
	public float zoomAmountDisplayOnly;
	public bool needsOnForEffects;
	public int burstCount;
	public float timeBetweenBursts;
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

	public class Modifier : MonoBehaviour
	{
	}

}