using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public int updatableIndex;
	public UnityEngine.Vector3 prevCameraPos;
	public float cameraVelSmoothSpeed;

	public class ScheduledSound : MonoBehaviour
	{
		public float startTime;
		public UnityEngine.Vector3 position;
		public float volumeMod;
	}

}