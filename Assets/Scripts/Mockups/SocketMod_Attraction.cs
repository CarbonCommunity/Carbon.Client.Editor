using UnityEngine;

public class SocketMod_Attraction : MonoBehaviour
{
	public float outerRadius;
	public float innerRadius;
	public bool lockRotation;
	public bool ignoreRotationForRadiusCheck;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

}