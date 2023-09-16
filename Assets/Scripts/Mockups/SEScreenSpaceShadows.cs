using UnityEngine;

public class SEScreenSpaceShadows : MonoBehaviour
{
	public float blendStrength;
	public float accumulation;
	public float lengthFade;
	public float range;
	public float zThickness;
	public int samples;
	public float nearSampleQuality;
	public float traceBias;
	public bool stochasticSampling;
	public bool leverageTemporalAA;
	public bool bilateralBlur;
	public int blurPasses;
	public float blurDepthTolerance;
	public bool sunInitialized;
	public int temporalJitterCounter;
	public bool previousBilateralBlurSetting;
	public int previousBlurPassesSetting;

}