using UnityEngine;

public class Horse : MonoBehaviour
{
	public float RealisticMass;
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
	public bool HasDisabledRenderers;
	public uint prefabID;
	public bool globalBroadcast;
	public bool globalBuildingBlock;
	public bool canTriggerParent;
	public bool isServer;
	public bool isClient;

}