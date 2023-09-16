using UnityEngine;

public class AmbienceWaveSounds : MonoBehaviour
{
	public int emitterCount;
	public float emitterDistance;

	public class WaveLayer : MonoBehaviour
	{
	}

	public class Emitter : MonoBehaviour
	{
		public UnityEngine.Vector3 localPosition;
	}

}