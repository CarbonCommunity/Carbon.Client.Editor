using UnityEngine;

public class VoiceProcessor : MonoBehaviour
{
	public float volumeMultiplier;
	public uint optimalRate;
	public uint bufferSize;
	public uint dataReceived;
	public uint playbackBuffer;
	public uint dataPosition;
	public bool Initialized;
	public float currentVolume;
	public bool isPlaying;
	public bool stopping;
	public float volumeVelocity;

}