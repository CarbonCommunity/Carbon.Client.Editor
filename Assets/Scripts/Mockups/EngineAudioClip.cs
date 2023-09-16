using UnityEngine;

public class EngineAudioClip : MonoBehaviour
{
	public int sampleRate;
	public int samplesUntilNextGrain;
	public int lastCycleId;
	public int currentRPM;
	public int targetRPM;
	public int minRPM;
	public int maxRPM;
	public int cyclePadding;
	public float RPMControl;
	public float rpmLerpSpeed;
	public float rpmLerpSpeedDown;
	public bool audioDataLoaded;

	public class EngineCycle : MonoBehaviour
	{
		public int RPM;
		public int startSample;
		public int endSample;
		public float period;
		public int id;
	}

	public class EngineCycleBucket : MonoBehaviour
	{
		public int RPM;
	}

	public class Grain : MonoBehaviour
	{
		public int startSample;
		public int currentSample;
		public int attackTimeSamples;
		public int sustainTimeSamples;
		public int releaseTimeSamples;
		public float gain;
		public float gainPerSampleAttack;
		public float gainPerSampleRelease;
		public int attackEndSample;
		public int releaseStartSample;
		public int endSample;
		public bool finished;
	}

}