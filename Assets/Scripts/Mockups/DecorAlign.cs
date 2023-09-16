using UnityEngine;

public class DecorAlign : MonoBehaviour
{
	public float NormalAlignment;
	public float GradientAlignment;
	public UnityEngine.Vector3 SlopeOffset;
	public UnityEngine.Vector3 SlopeScale;
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