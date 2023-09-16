using UnityEngine;

public class TerrainCarve : MonoBehaviour
{
	public float Opacity;
	public float Radius;
	public float Fade;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

}