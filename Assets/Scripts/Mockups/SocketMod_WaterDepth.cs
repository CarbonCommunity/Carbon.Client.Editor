using UnityEngine;

public class SocketMod_WaterDepth : MonoBehaviour
{
	public float MinimumWaterDepth;
	public float MaximumWaterDepth;
	public bool AllowWaterVolumes;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

}