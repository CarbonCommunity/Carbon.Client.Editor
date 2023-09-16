using UnityEngine;

public class Door : MonoBehaviour
{
	public bool canTakeLock;
	public bool hasHatch;
	public bool canTakeCloser;
	public bool canTakeKnocker;
	public bool canNpcOpen;
	public bool canHandOpen;
	public bool isSecurityDoor;
	public bool checkPhysBoxesOnOpen;
	public float openAnimLength;
	public float closeAnimLength;
	public bool animatorNeedsInitializing;
	public bool animatorIsOpen;
	public bool isAnimating;
	public bool grounded;
	public float cachedStability;
	public int cachedDistanceFromGround;
	public UnityEngine.Vector3 debrisRotationOffset;
	public uint buildingID;
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

}