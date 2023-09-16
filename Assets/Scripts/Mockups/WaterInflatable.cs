using UnityEngine;

public class WaterInflatable : MonoBehaviour
{
	public float forwardPushForce;
	public float rearPushForce;
	public float rotationForce;
	public float maxSpeed;
	public float maxPaddleFrequency;
	public float waterSoundSpeedDivisor;
	public float additiveDownhillVelocity;
	public float animationLerpSpeed;
	public float smoothedEyeSpeed;
	public bool driftTowardsIsland;
	public float handSplashOffset;
	public float velocitySplashMultiplier;
	public UnityEngine.Vector3 modifyEyeOffset;
	public float inheritVelocityMultiplier;
	public float movingParticlesThreshold;
	public float headSpaceCheckRadius;
	public UnityEngine.Vector3 smoothedAnimDirection;
	public UnityEngine.Vector3 smoothedEyePos;
	public bool IsSummerDlcVehicle;
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
	public float RealisticMass;
	public bool IsNpc;
	public bool HasDisabledRenderers;
	public uint prefabID;
	public bool globalBroadcast;
	public bool globalBuildingBlock;
	public bool canTriggerParent;
	public bool isServer;
	public bool isClient;

	public class PaddleDirection : MonoBehaviour
	{
	}

	public class ParticleType : MonoBehaviour
	{
	}

}