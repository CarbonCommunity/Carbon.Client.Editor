using UnityEngine;

public class WaterPurifier : MonoBehaviour
{
	public int waterToProcessPerMinute;
	public int freshWaterRatio;
	public bool stopWhenOutputFull;
	public int startingAmount;
	public bool autofillOutputs;
	public float autofillTickRate;
	public int autofillTickAmount;
	public int maxOutputFlow;
	public bool IsGravitySource;
	public bool DisregardGravityRestrictionsOnLiquid;
	public int maxStackSize;
	public int numSlots;
	public bool needsBuildingPrivilegeToUse;
	public bool isLootable;
	public bool dropsLoot;
	public bool dropFloats;
	public bool onlyOneUser;
	public int client_powerin;
	public int client_slotpower;
	public bool client_extradata_dirty;
	public float LiquidPassthroughGravityThreshold;
	public bool BlockIOInformationDisplay;
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

	public class WaterPurifierFlags : MonoBehaviour
	{
	}

}