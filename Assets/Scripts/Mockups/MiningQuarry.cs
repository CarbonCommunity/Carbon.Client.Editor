using UnityEngine;

public class MiningQuarry : MonoBehaviour
{
	public int scrollMatIndex;
	public float animatorSpeedChange;
	public float beltScrollSpeedMultiplier;
	public float processRate;
	public float workToAdd;
	public float workPerFuel;
	public float pendingWork;
	public bool isStatic;
	public float beltSpeed;
	public float beltPos;
	public bool canExtractLiquid;
	public bool canExtractSolid;
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

	public class QuarryType : MonoBehaviour
	{
	}

	public class ChildPrefab : MonoBehaviour
	{
	}

}