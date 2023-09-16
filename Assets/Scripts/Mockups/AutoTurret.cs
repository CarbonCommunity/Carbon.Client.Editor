using UnityEngine;

public class AutoTurret : MonoBehaviour
{
	public float bulletSpeed;
	public float nextFocusSound;
	public bool wasTurning;
	public UnityEngine.Vector3 aimDir;
	public float sightRange;
	public float focusSoundFreqMin;
	public float focusSoundFreqMax;
	public float aimCone;
	public float rcTurnSensitivity;
	public bool CanPing;
	public bool RequiresMouse;
	public float MaxRange;
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
	public bool IsGravitySource;
	public float LiquidPassthroughGravityThreshold;
	public bool DisregardGravityRestrictionsOnLiquid;
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

	public class TurretFlags : MonoBehaviour
	{
	}

}