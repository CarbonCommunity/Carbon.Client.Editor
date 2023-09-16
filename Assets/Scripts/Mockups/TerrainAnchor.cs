using UnityEngine;

public class TerrainAnchor : MonoBehaviour
{
	public float Extents;
	public float Offset;
	public float Radius;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

}