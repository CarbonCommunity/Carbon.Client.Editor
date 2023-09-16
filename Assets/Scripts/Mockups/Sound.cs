using UnityEngine;

public class Sound : MonoBehaviour
{
	public bool playing;
	public bool isFirstPerson;
	public float distanceScale;
	public int clipIndex;
	public bool hasDistantSound;
	public float length;
	public int FrameUpdateIndex;
	public UnityEngine.Vector3 previousPosition;
	public float previousPositionUpdateTime;
	public int priorityModifier;
	public float audioSourceVolue;
	public bool isAudioSourcePlaying;
	public int timeSamples;
	public float pan;
	public float maxDistance;

}