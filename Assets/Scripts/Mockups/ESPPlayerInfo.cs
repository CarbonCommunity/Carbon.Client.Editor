using UnityEngine;

public class ESPPlayerInfo : MonoBehaviour
{
	public UnityEngine.Vector3 WorldOffset;
	public bool inQueue;
	public UnityEngine.Vector3 playerVisPosHead;
	public UnityEngine.Vector3 playerVisPosSpine;
	public bool _showClanTag;
	public int numFramesVisible;
	public float distanceFromCamera;
	public bool CanShowSpectatingFeatures;

	public class ESPWorkQueue : MonoBehaviour
	{
		public long warnTime;
		public long totalProcessed;
		public int queueProcessedLast;
		public int hashsetMaxLength;
		public int queueLength;
	}

}