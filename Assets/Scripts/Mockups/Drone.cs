using UnityEngine;

public class Drone : MonoBehaviour
{
	public bool killInWater;
	public bool enableGrounding;
	public bool keepAboveTerrain;
	public float groundTraceDist;
	public float groundCheckInterval;
	public float altitudeAcceleration;
	public float movementAcceleration;
	public float yawSpeed;
	public float uprightSpeed;
	public float uprightPrediction;
	public float uprightDot;
	public float leanWeight;
	public float leanMaxVelocity;
	public float hurtVelocityThreshold;
	public float hurtDamagePower;
	public float collisionDisableTime;
	public float pitchMin;
	public float pitchMax;
	public float pitchSensitivity;
	public bool disableWhenHurt;
	public float disableWhenHurtChance;
	public float playerCheckInterval;
	public float playerCheckRadius;
	public float deployYOffset;
	public float movementSpeedReference;
	public float propellerMaxSpeed;
	public float propellerAcceleration;
	public float pitch;
	public float propellerAngle;
	public float propellerSpeed;
	public bool localClientIsControlling;
	public bool RequiresMouse;
	public float MaxRange;
	public bool CanPing;
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

	public class DroneInputState : MonoBehaviour
	{
	}

}