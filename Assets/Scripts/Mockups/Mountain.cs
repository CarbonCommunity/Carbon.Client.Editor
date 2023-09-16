using UnityEngine;

public class Mountain : MonoBehaviour
{
	public float Fade;
	public UnityEngine.Vector3 size;
	public UnityEngine.Vector3 extents;
	public UnityEngine.Vector3 offset;
	public bool HeightMap;
	public bool AlphaMap;
	public bool WaterMap;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

}