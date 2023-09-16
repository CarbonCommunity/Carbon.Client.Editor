using UnityEngine;

public class DemoShotRecorder : MonoBehaviour
{
	public float lastKeyframe;
	public bool hasStarted;
	public float countdownStartTime;
	public bool IsInCountdown;
	public float CurrentShotTime;
	public float ShotStartTime;

	public class RecorderSettings : MonoBehaviour
	{
		public bool Countdown;
		public bool PauseOnSave;
		public bool ReturnToShotStart;
		public bool RecordDof;
	}

}