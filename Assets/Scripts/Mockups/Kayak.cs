using UnityEngine;

public class Kayak : MonoBehaviour
{
	public float maxPaddleFrequency;
	public float forwardPaddleForce;
	public float multiDriverPaddleForceMultiplier;
	public float rotatePaddleForce;
	public float animationLerpSpeed;
	public float waterSoundSpeedDivisor;
	public float lastSoundUpdate;
	public float engineThrust;
	public float steeringScale;
	public bool preventDecayIndoors;
	public bool applyCorrectionForces;
	public UnityEngine.Vector3 inAirPID;
	public float inAirDesiredPitch;
	public UnityEngine.Vector3 wavePID;
	public float correctionSpringForce;
	public float correctionSpringDamping;
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

	public class PlayerAnimationState : MonoBehaviour
	{
	}

	public class PaddleDirection : MonoBehaviour
	{
	}

}