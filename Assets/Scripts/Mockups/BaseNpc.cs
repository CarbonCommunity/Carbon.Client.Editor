using UnityEngine;

public class BaseNpc : MonoBehaviour
{
	public int agentTypeIndex;
	public bool NewAI;
	public bool LegacyNavigation;
	public UnityEngine.Vector3 AttackOffset;
	public float AttackDamage;
	public float AttackCost;
	public float AttackRate;
	public float AttackRange;
	public float stuckDuration;
	public float lastStuckTime;
	public float idleDuration;
	public int ForgetUnseenEntityTime;
	public float SensesTickRate;
	public float nextVisThink;
	public float lastTimeSeen;
	public UnityEngine.Vector3 lastPosition;
	public bool IsNpc;
	public bool IsSitting;
	public bool IsChasing;
	public bool IsSleeping;
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
	public bool HasDisabledRenderers;
	public uint prefabID;
	public bool globalBroadcast;
	public bool globalBuildingBlock;
	public bool canTriggerParent;
	public bool isServer;
	public bool isClient;

	public class AiFlags : MonoBehaviour
	{
	}

	public class AiStatistics : MonoBehaviour
	{
		public float Size;
		public float Speed;
		public float Acceleration;
		public float TurnSpeed;
		public float Tolerance;
		public float VisionRange;
		public float VisionCone;
		public float Hostility;
		public float Defensiveness;
		public float AggressionRange;
		public float DeaggroRange;
		public float DeaggroChaseTime;
		public float DeaggroCooldown;
		public float HealthThresholdForFleeing;
		public float HealthThresholdFleeChance;
		public float MinFleeRange;
		public float MaxFleeRange;
		public float MaxFleeTime;
		public float AfraidRange;
		public float MinRoamRange;
		public float MaxRoamRange;
		public float MinRoamDelay;
		public float MaxRoamDelay;
		public bool IsMobile;
		public float AttackedMemoryTime;
		public float WakeupBlockMoveTime;
		public float MaxWaterDepth;
		public float WaterLevelNeck;
		public float WaterLevelNeckOffset;
		public float CloseRange;
		public float MediumRange;
		public float LongRange;
		public float OutOfRangeOfSpawnPointTimeout;
		public bool OnlyAggroMarkedTargets;
	}

}