using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
	public float NoiseRadius;
	public float damageScale;
	public float distanceScale;
	public float projectileVelocityScale;
	public bool automatic;
	public bool usableByTurret;
	public float turretDamageScale;
	public float reloadTime;
	public bool canUnloadAmmo;
	public bool fractionalReload;
	public float reloadStartDuration;
	public float reloadFractionDuration;
	public float reloadEndDuration;
	public float aimSway;
	public float aimSwaySpeed;
	public float aimCone;
	public float hipAimCone;
	public float aimconePenaltyPerShot;
	public float aimConePenaltyMax;
	public float aimconePenaltyRecoverTime;
	public float aimconePenaltyRecoverDelay;
	public float stancePenaltyScale;
	public bool hasADS;
	public bool noAimingWhileCycling;
	public bool manualCycle;
	public bool needsCycle;
	public bool isCycling;
	public bool aiming;
	public bool useEmptyAmmoState;
	public bool isBurstWeapon;
	public bool canChangeFireModes;
	public bool defaultOn;
	public float internalBurstRecoilScale;
	public float internalBurstFireRateScale;
	public float internalBurstAimConeScale;
	public float resetDuration;
	public int numShotsFired;
	public float nextReloadTime;
	public float startReloadTime;
	public float stancePenalty;
	public float aimconePenalty;
	public uint cachedModHash;
	public float sightAimConeScale;
	public float sightAimConeOffset;
	public float hipAimConeScale;
	public float hipAimConeOffset;
	public bool isReloading;
	public float swaySampleTime;
	public float lastShotTime;
	public float reloadPressTime;
	public int fractionalReloadDesiredCount;
	public int fractionalReloadNumAdded;
	public int currentBurst;
	public bool triggerReady;
	public float nextHeightCheckTime;
	public bool cachedUnderground;
	public bool isSemiAuto;
	public float deployDelay;
	public float repeatDelay;
	public float animationDelay;
	public float effectiveRange;
	public float npcDamageScale;
	public float attackLengthMin;
	public float attackLengthMax;
	public float attackSpacing;
	public float aiAimSwayOffset;
	public float aiAimCone;
	public bool aiOnlyInRange;
	public float CloseRangeAddition;
	public float MediumRangeAddition;
	public float LongRangeAddition;
	public bool CanUseAtMediumRange;
	public bool CanUseAtLongRange;
	public float recoilCompDelayOverride;
	public bool wantsRecoilComp;
	public float nextAttackTime;
	public float lastTickTime;
	public float nextTickTime;
	public float timeSinceDeploy;
	public float lastRecoilCompTime;
	public UnityEngine.Vector3 startAimingDirection;
	public bool wasDoingRecoilComp;
	public UnityEngine.Vector3 reductionSpeed;
	public bool UsingInfiniteAmmoCheat;
	public float NextAttackTime;
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

	public class Magazine : MonoBehaviour
	{
		public int capacity;
		public int contents;
	}

	public class BaseProjectileFlags : MonoBehaviour
	{
	}

}