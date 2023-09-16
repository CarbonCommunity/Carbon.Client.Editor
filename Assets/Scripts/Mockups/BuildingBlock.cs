using UnityEngine;

public class BuildingBlock : MonoBehaviour
{
	public bool forceSkinRefresh;
	public ulong lastSkinID;
	public int lastModelState;
	public uint lastCustomColour;
	public bool CullBushes;
	public bool CheckForPipesOnModelChange;
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

	public class BlockFlags : MonoBehaviour
	{
	}

	public class MeshRender : MonoBehaviour
	{
		public UnityEngine.Vector3 Position;
	}

	public class UpdateSkinWorkQueue : MonoBehaviour
	{
		public long warnTime;
		public long totalProcessed;
		public int queueProcessedLast;
		public int hashsetMaxLength;
		public int queueLength;
	}

}