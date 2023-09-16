using UnityEngine;

public class ConditionalModel : MonoBehaviour
{
	public bool onClient;
	public bool onServer;
	public bool IsImportant;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

}