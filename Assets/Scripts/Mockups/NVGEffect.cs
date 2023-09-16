using UnityEngine;

public class NVGEffect : MonoBehaviour
{
	public bool updateTexturesOnStartup;
	public bool supportImageEffects;
	public bool supportHDRTextures;
	public bool supportDepthTextures;
	public bool supportDX11;
	public bool checkedSystemInfo;
	public bool isSupported;

	public class ColorCorrectionParams : MonoBehaviour
	{
		public float saturation;
	}

	public class NoiseAndGrainParams : MonoBehaviour
	{
	}

}