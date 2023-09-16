using UnityEngine;

public class NaturalBloomAndDirtyLens : MonoBehaviour
{
	public float range;
	public float cutoff;
	public float bloomIntensity;
	public float lensDirtIntensity;
	public float spread;
	public int iterations;
	public int mips;
	public bool highPrecision;
	public bool downscaleSource;
	public bool debug;
	public bool temporalFilter;
	public float temporalFilterWeight;
	public float blurSize;

	public class Param : MonoBehaviour
	{
	}

}