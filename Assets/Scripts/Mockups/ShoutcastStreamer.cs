using UnityEngine;

public class ShoutcastStreamer : MonoBehaviour
{
	public bool _readingData;
	public int sampleRate;
	public bool canUpdate;
	public bool wantsShutdown;
	public bool waitAudio;
	public float waitUntilBuffer;
	public bool IsConnected;
	public bool IsPlayingBuiltinAudio;
	public uint BufferedData;
	public float BufferedPercentage;

}