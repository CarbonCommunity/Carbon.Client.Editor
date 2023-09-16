using UnityEngine;

public class RelationshipManager : MonoBehaviour
{
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

	public class RelationshipType : MonoBehaviour
	{
	}

	public class PlayerRelationshipInfo : MonoBehaviour
	{
		public ulong player;
		public int weight;
		public uint mugshotCrc;
		public float lastSeenTime;
		public uint loadedMugshotCrc;
		public bool mugshotLoading;
		public bool IsMugshotLoaded;
	}

	public class PlayerRelationships : MonoBehaviour
	{
		public bool dirty;
		public ulong ownerPlayer;
	}

}