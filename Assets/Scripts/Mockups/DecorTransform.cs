using UnityEngine;

public class DecorTransform : MonoBehaviour
{
	public UnityEngine.Vector3 Position;
	public UnityEngine.Vector3 Rotation;
	public UnityEngine.Vector3 Scale;
	public bool isRoot;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

}