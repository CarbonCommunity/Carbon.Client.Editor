using UnityEngine;

public class MusicChangeIntensity : MonoBehaviour
{
	public float raiseTo;
	public float tickInterval;
	public float lastTick;

	public class DistanceIntensity : MonoBehaviour
	{
		public float distance;
		public float raiseTo;
		public bool forceStartMusicInSuppressedMusicZones;
	}

}