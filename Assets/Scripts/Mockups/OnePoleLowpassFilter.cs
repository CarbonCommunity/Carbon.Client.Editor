using UnityEngine;

public class OnePoleLowpassFilter : MonoBehaviour
{
	public float frequency;
	public int sampleRate;
	public float c;
	public float a1;
	public float b1;
	public float prevFrequency;

	public class ChannelData : MonoBehaviour
	{
		public float out1;
	}

}