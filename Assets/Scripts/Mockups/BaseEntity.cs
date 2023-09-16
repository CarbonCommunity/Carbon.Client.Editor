using UnityEngine;

public class BaseEntity : MonoBehaviour
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

	public class Menu : MonoBehaviour
	{
		public int Order;
		public float Time;
		public bool LongUseOnly;
		public bool PrioritizeIfNotWhitelisted;
		public bool PrioritizeIfUnlocked;
	}

	public class MovementModify : MonoBehaviour
	{
	}

	public class GiveItemReason : MonoBehaviour
	{
	}

	public class Flags : MonoBehaviour
	{
	}

	public class QueuedFileRequest : MonoBehaviour
	{
		public uint Part;
		public uint Crc;
		public uint ResponseFunction;
	}

	public class PendingFileRequest : MonoBehaviour
	{
		public uint NumId;
		public uint Crc;
		public float Time;
	}

	public class Query : MonoBehaviour
	{
	}

	public class RPC_Shared : MonoBehaviour
	{
	}

	public class RPCMessage : MonoBehaviour
	{
	}

	public class RPC_Client : MonoBehaviour
	{
	}

	public class Signal : MonoBehaviour
	{
	}

	public class Slot : MonoBehaviour
	{
	}

	public class TraitFlag : MonoBehaviour
	{
	}

	public class Util : MonoBehaviour
	{
	}

}