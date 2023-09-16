using UnityEngine;

public class SlicedGranularAudioClip : MonoBehaviour
{
	public int sampleRate;
	public float grainAttack;
	public float grainSustain;
	public float grainRelease;
	public float grainFrequency;
	public int grainAttackSamples;
	public int grainSustainSamples;
	public int grainReleaseSamples;
	public int grainFrequencySamples;
	public int samplesUntilNextGrain;
	public int lastStartPositionIdx;
	public int sourceChannels;
	public bool audioDataLoaded;

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