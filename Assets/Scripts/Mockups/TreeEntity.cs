using UnityEngine;

public class TreeEntity : MonoBehaviour
{
	public bool fallOnKilled;
	public float fallDuration;
	public bool impactSoundPlayed;
	public float treeDistanceUponFalling;
	public UnityEngine.Vector3 oldSkinPos;
	public float lastTreeFallTickTime;
	public float fallStartTime;
	public UnityEngine.Vector3 hitDirection;
	public UnityEngine.Vector3 rotateDirection;
	public float impactSoundCheckHeight;
	public bool hasBonusGame;
	public float lastAttackDamage;
	public float startHealth;
	public float health;
	public bool isKilled;
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