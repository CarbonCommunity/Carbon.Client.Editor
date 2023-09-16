using UnityEngine;

public class BaseRidableAnimal : MonoBehaviour
{
	public int maxStackSize;
	public int numSlots;
	public bool needsBuildingPrivilegeToUse;
	public bool isLootable;
	public UnityEngine.Vector3 lastMoveDirection;
	public float obstacleDetectionRadius;
	public float maxWaterDepth;
	public float roadSpeedBonus;
	public float maxWallClimbSlope;
	public float maxStepHeight;
	public float maxStepDownHeight;
	public float walkSpeed;
	public float trotSpeed;
	public float runSpeed;
	public float turnSpeed;
	public float maxSpeed;
	public float staminaSeconds;
	public float currentMaxStaminaSeconds;
	public float maxStaminaSeconds;
	public float staminaCoreLossRatio;
	public float staminaCoreSpeedBonus;
	public float staminaReplenishRatioMoving;
	public float staminaReplenishRatioStanding;
	public float calorieToStaminaRatio;
	public float hydrationToStaminaRatio;
	public float maxStaminaCoreFromWater;
	public bool debugMovement;
	public float currentSpeed;
	public float desiredRotation;
	public float animalPitchClamp;
	public float animalRollClamp;
	public float lastBreathingRate;
	public float nextTokenCheckTime;
	public bool IsNpc;
	public bool mountChaining;
	public bool checkVehicleClipping;
	public bool shouldShowHudHealth;
	public bool ignoreDamageFromOutside;
	public bool doClippingAndVisChecks;
	public float explosionForceMultiplier;
	public float explosionForceMax;
	public bool IsMovingOrOn;
	public float RealisticMass;
	public UnityEngine.Vector2 pitchClamp;
	public UnityEngine.Vector2 yawClamp;
	public bool canWieldItems;
	public bool relativeViewAngles;
	public float mountLOSVertOffset;
	public float maxMountDistance;
	public bool checkPlayerLosOnMount;
	public bool disableMeshCullingForPlayers;
	public bool allowHeadLook;
	public bool ignoreVehicleParent;
	public bool legacyDismount;
	public bool modifiesPlayerCollider;
	public bool canDrinkWhileMounted;
	public bool allowSleeperMounting;
	public bool animateClothInLocalSpace;
	public bool isMobile;
	public float SideLeanAmount;
	public bool DisableLegsMeshAtExtremeViewAnglesInFirstPersonWithEyes;
	public float FirstPersonWithArmsEyesLerp;
	public bool IsSummerDlcVehicle;
	public bool BlocksDoors;
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
	public bool HasDisabledRenderers;
	public uint prefabID;
	public bool globalBroadcast;
	public bool globalBuildingBlock;
	public bool canTriggerParent;
	public bool isServer;
	public bool isClient;

	public class PurchaseOption : MonoBehaviour
	{
		public int order;
	}

	public class RunState : MonoBehaviour
	{
	}

}