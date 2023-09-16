using UnityEngine;

public class SimpleShark : MonoBehaviour
{
	public UnityEngine.Vector3 destination;
	public float minSpeed;
	public float maxSpeed;
	public float idealDepth;
	public float minTurnSpeed;
	public float maxTurnSpeed;
	public float attackCooldown;
	public float aggroRange;
	public float obstacleDetectionRadius;
	public float currentMouthOpen;
	public bool IsNpc;
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

}