using UnityEngine;

public class PatrolHelicopter : MonoBehaviour
{
	public int maxCratesToSpawn;
	public float bulletSpeed;
	public float bulletDamage;
	public float flareDuration;
	public float rotorGainModSmoothing;
	public float engineGainMin;
	public float engineGainMax;
	public float thwopGainMin;
	public float thwopGainMax;
	public float spotlightJitterAmount;
	public float spotlightJitterSpeed;
	public UnityEngine.Vector3 spotlightTarget;
	public float engineSpeed;
	public float targetEngineSpeed;
	public float blur_rotationScale;
	public bool nightLightsOn;
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

	public class weakspot : MonoBehaviour
	{
		public float maxHealth;
		public float health;
		public float healthFractionOnDestroyed;
	}

}