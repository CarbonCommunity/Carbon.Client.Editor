using UnityEngine;

public class PetCommandList : MonoBehaviour
{
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

	public class PetCommandDesc : MonoBehaviour
	{
		public int CommandIndex;
		public bool Raycast;
		public int CommandWheelOrder;
	}

}