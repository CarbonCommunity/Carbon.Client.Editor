using UnityEngine;

public class LightEx : MonoBehaviour
{
	public bool alterColor;
	public float colorTimeScale;
	public bool loopColor;
	public bool alterIntensity;
	public float intensityTimeScale;
	public float intensityCurveScale;
	public bool loopIntensity;
	public bool randomOffset;
	public float randomIntensityStartScale;
	public float initialRange;
	public float initialIntensity;
	public bool canToggleLight;
	public float time;
	public float lastUpdate;
	public float nextUpdate;

	public class SyncLightData : MonoBehaviour
	{
	}

}