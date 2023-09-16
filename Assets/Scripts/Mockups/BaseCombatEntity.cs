using UnityEngine;

public class BaseCombatEntity : MonoBehaviour
{
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

	public class LifeState : MonoBehaviour
	{
	}

	public class Faction : MonoBehaviour
	{
	}

	public class Pickup : MonoBehaviour
	{
		public int itemCount;
		public bool setConditionFromHealth;
		public float subtractCondition;
		public bool requireBuildingPrivilege;
		public bool requireHammer;
		public bool requireEmptyInv;
		public float overridePickupTime;
	}

	public class Repair : MonoBehaviour
	{
	}

}