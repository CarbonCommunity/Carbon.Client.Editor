using UnityEngine;

public class TrainEngineAudio : MonoBehaviour
{
	public float engineActiveLoopChangeSpeed;
	public float reflectionMaxDistance;
	public float reflectionGainChangeSpeed;
	public float reflectionPositionChangeSpeed;
	public float reflectionRayOffset;
	public float movementChangeOneshotDebounce;
	public float lastMovementChangeOneshot;

	public class EngineReflection : MonoBehaviour
	{
		public UnityEngine.Vector3 direction;
		public UnityEngine.Vector3 offset;
		public float distance;
	}

}