using UnityEngine;

public class ReflectionProbeEx : MonoBehaviour
{
	public bool timeSlicing;
	public int resolution;
	public bool hdr;
	public float shadowDistance;
	public float nearClip;
	public float farClip;
	public float textureMipBias;
	public bool highPrecision;
	public bool enableShadows;
	public float reflectionIntensity;
	public int probeResolution;
	public bool probeHdr;
	public float probeShadowDistance;
	public float probeNearClip;
	public float probeFarClip;
	public bool probeHighPrecision;
	public bool scriptingRenderQueued;
	public int prevFrame;
	public int mipmapCount;
	public bool useGeometryShader;
	public int PassCount;

	public class ConvolutionQuality : MonoBehaviour
	{
	}

	public class RenderListEntry : MonoBehaviour
	{
		public bool alwaysEnabled;
	}

	public class TimeSlicingState : MonoBehaviour
	{
	}

	public class CubemapSkyboxVertex : MonoBehaviour
	{
	}

	public class CubemapFaceMatrices : MonoBehaviour
	{
	}

}