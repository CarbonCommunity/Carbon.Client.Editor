using UnityEngine;

public class MagnetCrane : MonoBehaviour
{
	public float leftTreadInput;
	public float rightTreadInput;
	public float arm1Speed;
	public float arm2Speed;
	public float turnYawSpeed;
	public float maxDistanceFromOrigin;
	public float idleFuelPerSec;
	public float maxFuelPerSec;
	public int engineKW;
	public float DriveWheelVelocity;
	public float engineStartupTime;
	public float minCollisionDamageForce;
	public float maxCollisionDamageForce;
	public float collisionDamageMultiplier;
	public bool runningClientTick;
	public bool LightsAreOn;
	public bool ShouldClientTick;
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

	public class MagnetCraneSnapshot : MonoBehaviour
	{
		public float Time;
	}

}