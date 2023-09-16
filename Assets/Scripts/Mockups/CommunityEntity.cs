using UnityEngine;

public class CommunityEntity : MonoBehaviour
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

	public class Countdown : MonoBehaviour
	{
		public int endTime;
		public int startTime;
		public int step;
		public int sign;
	}

	public class FadeOut : MonoBehaviour
	{
		public float duration;
	}

	public class CachedTexture : MonoBehaviour
	{
	}

}