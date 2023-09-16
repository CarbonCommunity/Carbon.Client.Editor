using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
	public float liftAmount;
	public float inflationLevel;
	public float fuelPerSec;
	public float NextUpgradeTime;
	public float windForce;
	public UnityEngine.Vector3 currentWindVec;
	public UnityEngine.Bounds collapsedBounds;
	public UnityEngine.Bounds raisedBounds;
	public float currentClientInflationLevel;
	public UnityEngine.Vector3 windSockVec;
	public float nextItemCheckTime;
	public bool IsFullyInflated;
	public bool Grounded;
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

	public class UpgradeOption : MonoBehaviour
	{
		public int order;
	}

}