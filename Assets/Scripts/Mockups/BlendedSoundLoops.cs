using UnityEngine;

public class BlendedSoundLoops : MonoBehaviour
{
	public float blend;
	public float blendSmoothing;
	public float loopFadeOutTime;
	public float loopFadeInTime;
	public float gainModSmoothing;
	public float pitchModSmoothing;
	public bool shouldPlay;
	public float gain;
	public float maxDistance;
	public float smoothedBlend;

	public class Loop : MonoBehaviour
	{
	}

}