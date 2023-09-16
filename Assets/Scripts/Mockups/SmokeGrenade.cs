using UnityEngine;

public class SmokeGrenade : MonoBehaviour
{
	public float smokeDuration;
	public float fieldMin;
	public float fieldMax;
	public float timerAmountMin;
	public float timerAmountMax;
	public float minExplosionRadius;
	public float explosionRadius;
	public bool explodeOnContact;
	public bool canStick;
	public bool onlyDamageParent;
	public bool BlindAI;
	public float aiBlindDuration;
	public float aiBlindRange;
	public float underwaterExplosionDepth;
	public bool explosionUsesForward;
	public bool waterCausesExplosion;
	public float lastBounceTime;
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