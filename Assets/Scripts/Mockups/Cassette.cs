using UnityEngine;

public class Cassette : MonoBehaviour
{
	public float MaxCassetteLength;
	public ulong CreatorSteamId;
	public int ViewmodelIndex;
	public int MaximumVoicemailSlots;
	public int preloadedAudioId;
	public uint cachedId;
	public bool notifyOnLoad;
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

	public class LoadRequest : MonoBehaviour
	{
	}

}