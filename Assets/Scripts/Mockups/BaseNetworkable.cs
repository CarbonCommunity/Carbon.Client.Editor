using UnityEngine;

public class BaseNetworkable : MonoBehaviour
{
	public uint prefabID;
	public bool globalBroadcast;
	public bool globalBuildingBlock;
	public bool canTriggerParent;
	public bool isServer;
	public bool isClient;

	public class SaveInfo : MonoBehaviour
	{
		public bool forDisk;
		public bool forTransfer;
	}

	public class LoadInfo : MonoBehaviour
	{
		public bool fromDisk;
		public bool fromTransfer;
	}

	public class EntityRealmClient : MonoBehaviour
	{
		public int Count;
	}

	public class EntityRealm : MonoBehaviour
	{
		public int Count;
	}

	public class DestroyMode : MonoBehaviour
	{
	}

}