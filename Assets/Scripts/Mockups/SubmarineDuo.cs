using UnityEngine;

public class SubmarineDuo : MonoBehaviour
{
	public float smoothedSpeed;
	public float flagLerp;
	public bool torpedoJustFired;
	public UnityEngine.Vector3 torpedoVec;
	public bool runningClientTick;
	public bool playedDiveBubbles;
	public bool playedWindowFilm;
	public float baseAlphaInside;
	public float baseAlphaOutside;
	public float maxRudderAngle;
	public float timeUntilAutoSurface;
	public float engineKW;
	public float turnPower;
	public float engineStartupTime;
	public float depthChangeTargetSpeed;
	public float idleFuelPerSec;
	public float maxFuelPerSec;
	public bool internalAccessStorage;
	public float reloadTime;
	public float mountedAlphaInside;
	public float mountedAlphaOutside;
	public float _throttle;
	public float _rudder;
	public float _upDown;
	public float _oxygen;
	public float cachedFuelAmount;
	public UnityEngine.Vector3 steerAngle;
	public float waterSurfaceY;
	public float curSubDepthY;
	public int waterLayerMask;
	public bool LightsAreOn;
	public bool HasAmmo;
	public float ThrottleInput;
	public float RudderInput;
	public float UpDownInput;
	public float Oxygen;
	public float PhysicalRudderAngle;
	public bool IsInWater;
	public bool IsSurfaced;
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

	public class FlagState : MonoBehaviour
	{
	}

	public class TorpedoDoorState : MonoBehaviour
	{
	}

}