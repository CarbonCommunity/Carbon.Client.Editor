using UnityEngine;

public class ClanManager : MonoBehaviour
{
	public int _nextRequestId;
	public bool _clanInfoDirty;
	public bool _clanInfoAutoRefreshing;
	public float _nextMetadataRequestTime;
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

	public class ClanMetadataCacheEntry : MonoBehaviour
	{
		public float Timestamp;
	}

}