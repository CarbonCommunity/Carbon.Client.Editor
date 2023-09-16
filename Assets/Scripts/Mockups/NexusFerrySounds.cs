using UnityEngine;

public class NexusFerrySounds : MonoBehaviour
{
	public float roughHalfWidth;
	public float roughHalfLength;
	public float soundCullDistanceSq;
	public float engineGainChangeRate;
	public float enginePitchChangeRate;
	public float waterMovementGainChangeRate;
	public UnityEngine.Vector3 sideSoundLineStern;
	public UnityEngine.Vector3 sideSoundLineBow;
	public bool engineOn;
	public UnityEngine.Vector3 lastPosition;
	public UnityEngine.Vector3 velocity;
	public float speed;
	public bool wasEngineOn;

}