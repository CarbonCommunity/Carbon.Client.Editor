using UnityEngine;

public class BasePlayer : MonoBehaviour
{
	public long clanId;
	public bool Frozen;
	public int bagCount;
	public float wakeTime;
	public bool needsClothesRebuild;
	public bool wasSleeping;
	public bool wokeUpBefore;
	public bool wasDead;
	public uint lastClothesHash;
	public UnityEngine.Vector3 lastRevivePoint;
	public UnityEngine.Vector3 lastReviveDirection;
	public float respawnOptionsTimestamp;
	public float nextTopologyTestTime;
	public float usePressTime;
	public float useHeldTime;
	public UnityEngine.Vector3 cachedWaterDrinkingPoint;
	public bool hasRequestedServerEmoji;
	public float nextGestureMenuOpenTime;
	public float client_lastHelloTime;
	public ulong currentTeam;
	public float lastReceivedTeamTime;
	public ulong lastPresenceTeamId;
	public int lastPresenceTeamSize;
	public bool keepOpenMapInterface;
	public int _activeMission;
	public float nextSeatSwapTime;
	public bool mountInputHeldDuringDismount;
	public float lastPetCommandIssuedTime;
	public uint PetPrefabID;
	public bool tapInProcess;
	public float cachedBuildingPrivilegeTime;
	public float cachedVehicleBuildingBlockedTime;
	public bool cachedVehicleBuildingBlocked;
	public int maxProjectileID;
	public float lastUpdateTime;
	public float cachedThreatLevel;
	public int serverTickRate;
	public int clientTickRate;
	public float serverTickInterval;
	public float clientTickInterval;
	public float lastSentTickTime;
	public float nextVisThink;
	public float lastTimeSeen;
	public bool debugPrevVisible;
	public ulong userID;
	public int gamemodeteam;
	public int reputation;
	public float lastHeadshotSoundTime;
	public float nextColliderRefreshTime;
	public bool clothingBlocksAiming;
	public float clothingMoveSpeedReduction;
	public float clothingWaterSpeedBonus;
	public float clothingAccuracyBonus;
	public bool equippingBlocked;
	public float eggVision;
	public float TimeAwake;
	public bool shouldDrawBody;
	public float RespawnOptionsTimestamp;
	public bool IsReceivingSnapshot;
	public bool IsAdmin;
	public bool IsDeveloper;
	public bool UnlockAllSkins;
	public bool IsAiming;
	public bool IsFlying;
	public bool IsConnected;
	public bool InGesture;
	public bool CurrentGestureBlocksMovement;
	public bool CurrentGestureIsDance;
	public bool CurrentGestureIsFullBody;
	public bool InGestureCancelCooldown;
	public float clientTeamLifetime;
	public bool isMounted;
	public bool isMountingHidingWeapon;
	public bool IsBot;
	public bool HasActiveTelephone;
	public bool IsDesigningAI;
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

	public class CameraMode : MonoBehaviour
	{
	}

	public class PlayerFlags : MonoBehaviour
	{
	}

	public class MapNoteType : MonoBehaviour
	{
	}

	public class PingType : MonoBehaviour
	{
	}

	public class PingStyle : MonoBehaviour
	{
		public int IconIndex;
		public int ColourIndex;
	}

	public class TimeCategory : MonoBehaviour
	{
	}

	public class CapsuleColliderInfo : MonoBehaviour
	{
	}

}