using UnityEngine;

public class ConstructionSocket : MonoBehaviour
{
	public int rotationDegrees;
	public int rotationOffset;
	public bool restrictPlacementRotation;
	public bool restrictPlacementAngle;
	public float faceAngle;
	public float angleAllowed;
	public float support;
	public bool male;
	public bool maleDummy;
	public bool female;
	public bool femaleDummy;
	public bool femaleNoStability;
	public bool monogamous;
	public UnityEngine.Vector3 position;
	public UnityEngine.Vector3 selectSize;
	public UnityEngine.Vector3 selectCenter;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

	public class Type : MonoBehaviour
	{
	}

}