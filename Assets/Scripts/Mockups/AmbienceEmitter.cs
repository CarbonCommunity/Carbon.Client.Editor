using UnityEngine;

public class AmbienceEmitter : MonoBehaviour
{
	public bool isStatic;
	public bool followCamera;
	public bool isBaseEmitter;
	public bool active;
	public float cameraDistanceSq;
	public float crossfadeTime;
	public float deactivateTime;
	public bool playUnderwater;
	public bool playAbovewater;
	public float lastCrossfade;
	public int readingsToKeep;
	public UnityEngine.Vector3 lastPosition;

}