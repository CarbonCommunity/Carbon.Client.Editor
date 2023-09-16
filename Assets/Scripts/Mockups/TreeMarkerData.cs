using UnityEngine;

public class TreeMarkerData : MonoBehaviour
{
	public UnityEngine.Vector3 GenerationStartPoint;
	public float GenerationRadius;
	public float MaxY;
	public float MinY;
	public bool ProcessAngleChecks;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

	public class MarkerLocation : MonoBehaviour
	{
	}

	public class GenerationArc : MonoBehaviour
	{
	}

}