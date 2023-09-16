using UnityEngine;

public class WaterSystem : MonoBehaviour
{
	public int patchSize;
	public int patchCount;
	public float patchScale;
	public float lastQualityChange;
	public float reflectionProbeUpdateTime;
	public bool reflectionProbeReady;
	public int Layer;
	public int Reflections;
	public float WindowDirection;

	public class RenderingSettings : MonoBehaviour
	{
	}

}