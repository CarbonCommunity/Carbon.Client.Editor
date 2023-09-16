using UnityEngine;

public class BradleyAPC : MonoBehaviour
{
	public float chasisLurchAngleDelta;
	public float chasisLurchSpeedDelta;
	public float lastAngle;
	public float lastSpeed;
	public float turretLoopGainSpeed;
	public float turretLoopPitchSpeed;
	public float turretLoopMinAngleDelta;
	public float turretLoopMaxAngleDelta;
	public float turretLoopPitchMin;
	public float turretLoopPitchMax;
	public float turretLoopGainThreshold;
	public float enginePitch;
	public float rpmMultiplier;
	public float lastTurretAngle;
	public float moveForceMax;
	public float brakeForce;
	public float turnForce;
	public float sideStiffnessMax;
	public float sideStiffnessMin;
	public float stoppingDist;
	public float throttle;
	public float turning;
	public float rightThrottle;
	public float leftThrottle;
	public bool brake;
	public UnityEngine.Vector3 destination;
	public UnityEngine.Vector3 finalDestination;
	public UnityEngine.Vector3 turretAimVector;
	public UnityEngine.Vector3 desiredAimVector;
	public UnityEngine.Vector3 topTurretAimVector;
	public UnityEngine.Vector3 desiredTopTurretAimVector;
	public int maxCratesToSpawn;
	public int patrolPathIndex;
	public bool DoAI;
	public float recoilScale;
	public int navMeshPathIndex;
	public int currentPathIndex;
	public bool pathLooping;
	public float viewDistance;
	public float searchRange;
	public float searchFrequency;
	public float memoryDuration;
	public float coaxFireRate;
	public int coaxBurstLength;
	public float coaxAimCone;
	public float bulletDamage;
	public float topTurretFireRate;
	public float lastLateUpdate;
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

	public class TargetInfo : MonoBehaviour
	{
		public float damageReceivedFrom;
		public float lastSeenTime;
		public UnityEngine.Vector3 lastSeenPosition;
	}

}