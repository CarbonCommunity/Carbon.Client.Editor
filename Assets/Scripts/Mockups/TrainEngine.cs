using UnityEngine;

public class TrainEngine : MonoBehaviour
{
	public int clientFuelAmount;
	public int clientNumConnectedCars;
	public int clientLinedUpToUnload;
	public float lastUpdateHealth;
	public bool wasBraking;
	public bool highlightCouplingInfo;
	public float engineForce;
	public float maxSpeed;
	public float engineStartupTime;
	public float idleFuelPerSec;
	public float maxFuelPerSec;
	public bool lootablesAreOnPlatform;
	public bool mustMountFromPlatform;
	public float engineDamageToSlow;
	public float engineDamageTimeframe;
	public float engineSlowedTime;
	public float engineSlowedMaxVel;
	public bool LightsAreOn;
	public bool CloseToHazard;
	public bool EngineIsSlowed;
	public bool runningClientTick;
	public UnityEngine.Vector3 bogieRotation;
	public UnityEngine.Vector3 prevWheelRotation;
	public float corpseSeconds;
	public float collisionDamageDivide;
	public float derailCollisionForce;
	public float hurtTriggerMinSpeed;
	public bool frontBogieCanRotate;
	public bool rearBogieCanRotate;
	public float wheelRadius;
	public float decayTimeMultiplier;
	public UnityEngine.Vector3 frontBogieLocalOffset;
	public UnityEngine.Vector3 rearBogieLocalOffset;
	public float DistFrontWheelToFrontCoupling;
	public float DistFrontWheelToBackCoupling;
	public bool LinedUpToUnload;
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
	public bool IsNpc;
	public bool HasDisabledRenderers;
	public uint prefabID;
	public bool globalBroadcast;
	public bool globalBuildingBlock;
	public bool canTriggerParent;
	public bool isServer;
	public bool isClient;

	public class TrainMovementState : MonoBehaviour
	{
	}

	public class LeverStyle : MonoBehaviour
	{
	}

	public class EngineSpeeds : MonoBehaviour
	{
	}

}