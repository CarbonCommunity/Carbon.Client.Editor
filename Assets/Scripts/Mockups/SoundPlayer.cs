using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
	public bool playImmediately;
	public float minStartDelay;
	public float maxStartDelay;
	public bool debugRepeat;
	public bool pending;
	public UnityEngine.Vector3 soundOffset;
	public int playOnFrame;

}