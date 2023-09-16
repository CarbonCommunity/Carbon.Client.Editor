using UnityEngine;

public class Deployable : MonoBehaviour
{
	public UnityEngine.Vector3 guideMeshScale;
	public bool guideLights;
	public bool wantsInstanceData;
	public bool copyInventoryFromItem;
	public bool setSocketParent;
	public bool toSlot;
	public UnityEngine.Bounds bounds;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

}