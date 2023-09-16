using UnityEngine;

public class SoundFade : MonoBehaviour
{
	public float currentGain;
	public float startingGain;
	public float finalGain;
	public int sampleRate;
	public bool highQualityFadeCompleted;
	public float length;
	public float startTime;
	public float fadeOutTimeFinished;
	public float fadeOutTimeBuffer;
	public bool isFading;
	public bool isFadingOut;
	public bool isFadingIn;
	public float fadeTimeLeft;

	public class Direction : MonoBehaviour
	{
	}

}