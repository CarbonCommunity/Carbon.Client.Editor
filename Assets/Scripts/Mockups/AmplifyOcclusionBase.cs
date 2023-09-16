using UnityEngine;

public class AmplifyOcclusionBase : MonoBehaviour
{
	public float Intensity;
	public float Radius;
	public int PixelRadiusLimit;
	public float RadiusIntensity;
	public float PowerExponent;
	public float Bias;
	public float Thickness;
	public bool Downsample;
	public bool FadeEnabled;
	public float FadeStart;
	public float FadeLength;
	public float FadeToIntensity;
	public float FadeToRadius;
	public float FadeToPowerExponent;
	public float FadeToThickness;
	public bool BlurEnabled;
	public int BlurRadius;
	public int BlurPasses;
	public float BlurSharpness;
	public bool FilterEnabled;
	public float FilterBlending;
	public float FilterResponse;
	public bool TemporalDirections;
	public bool TemporalOffsets;
	public bool TemporalDilation;
	public bool UseMotionVectors;
	public bool m_prevDeferredReflections;
	public bool m_prevDownsample;
	public bool m_prevBlurEnabled;
	public int m_prevBlurRadius;
	public int m_prevBlurPasses;
	public bool m_paramsChanged;
	public uint m_sampleStep;
	public uint m_curStepIdx;

	public class ApplicationMethod : MonoBehaviour
	{
	}

	public class PerPixelNormalSource : MonoBehaviour
	{
	}

	public class SampleCountLevel : MonoBehaviour
	{
	}

	public class CmdBuffer : MonoBehaviour
	{
	}

	public class TargetDesc : MonoBehaviour
	{
	}

	public class ShaderPass : MonoBehaviour
	{
	}

	public class PropertyID : MonoBehaviour
	{
	}

}