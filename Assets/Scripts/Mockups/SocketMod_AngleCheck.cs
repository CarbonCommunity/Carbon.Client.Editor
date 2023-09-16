using UnityEngine;

public class SocketMod_AngleCheck : MonoBehaviour
{
	public bool wantsAngle;
	public UnityEngine.Vector3 worldNormal;
	public float withinDegrees;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

}