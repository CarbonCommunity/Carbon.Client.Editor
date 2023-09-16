using UnityEngine;

public class AtmosphereVolumeRenderer : MonoBehaviour
{
	public bool DistanceFog;
	public bool HeightFog;

	public class CurrentVolumeEntry : MonoBehaviour
	{
		public float distanceSqr;
	}

}