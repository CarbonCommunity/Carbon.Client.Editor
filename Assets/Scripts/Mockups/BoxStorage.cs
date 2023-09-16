using UnityEngine;

public class BoxStorage : MonoBehaviour
{
	public int inventorySlots;
	public bool dropsLoot;
	public float dropLootDestroyPercent;
	public bool dropFloats;
	public bool isLootable;
	public bool isLockable;
	public bool isMonitorable;
	public int maxStackSize;
	public bool needsBuildingPrivilegeToUse;
	public bool mustBeMountedToUse;
	public UnityEngine.Vector3 dropPosition;
	public UnityEngine.Vector3 dropVelocity;
	public bool onlyOneUser;
	public UnityEngine.Vector3 debrisRotationOffset;
	public uint buildingID;
	public float startHealth;
	public bool ShowHealthInfo;
	public bool sendsHitNotification;
	public bool sendsMeleeHitNotification;
	public bool markAttackerHostile;
	public float _health;
	public float _maxHealth;
	public float deathTime;
	public int lastNotifyFrame;
	public float SecondsSinceDeath;
	public float healthFraction;
	public float health;
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