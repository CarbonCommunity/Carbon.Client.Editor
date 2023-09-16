using UnityEngine;

public class ModelConditionTest_RoofLeft : MonoBehaviour
{
	public bool IsConvex;
	public bool IsConcave;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

	public class AngleType : MonoBehaviour
	{
	}

	public class ShapeType : MonoBehaviour
	{
	}

}