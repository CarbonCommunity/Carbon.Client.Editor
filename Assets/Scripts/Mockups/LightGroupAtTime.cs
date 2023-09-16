using UnityEngine;

public class LightGroupAtTime : MonoBehaviour
{
	public float IntensityOverride;
	public bool requiresPower;
	public float timeBetweenPowerLookup;
	public float intensityOverride;
	public int lightIndex;
	public int lightLODIndex;
	public int beamIndex;
	public int rendererIndex;
	public int simpleFlareIndex;
	public int distanceFlareIndex;
	public int EmissionPropertyID;
	public int ColorFlatPropertyID;
	public int LightsPerFrame;
	public int LightLODsPerFrame;
	public int BeamsPerFrame;
	public int RenderersPerFrame;
	public int SimpleFlaresPerFrame;
	public int DistanceFlaresPerFrame;

	public class EmissiveCols : MonoBehaviour
	{
	}

	public class LightGroupWorkQueue : MonoBehaviour
	{
		public long warnTime;
		public int currentIndex;
		public int listLength;
	}

}