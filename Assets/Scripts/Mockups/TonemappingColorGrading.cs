using UnityEngine;

public class TonemappingColorGrading : MonoBehaviour
{
	public float m_TonemapperCurveRange;
	public bool m_Dirty;
	public bool m_TonemapperDirty;
	public bool isGammaColorSpace;
	public int lutSize;

	public class SettingsGroup : MonoBehaviour
	{
	}

	public class IndentedGroup : MonoBehaviour
	{
		public int order;
	}

	public class ChannelMixer : MonoBehaviour
	{
		public int order;
	}

	public class ColorWheelGroup : MonoBehaviour
	{
		public int minSizePerWheel;
		public int maxSizePerWheel;
		public int order;
	}

	public class Curve : MonoBehaviour
	{
		public int order;
	}

	public class EyeAdaptationSettings : MonoBehaviour
	{
	}

	public class Tonemapper : MonoBehaviour
	{
	}

	public class TonemappingSettings : MonoBehaviour
	{
		public float exposure;
		public float neutralBlackIn;
		public float neutralWhiteIn;
		public float neutralBlackOut;
		public float neutralWhiteOut;
		public float neutralWhiteLevel;
		public float neutralWhiteClip;
	}

	public class LUTSettings : MonoBehaviour
	{
		public float contribution;
	}

	public class ColorWheelsSettings : MonoBehaviour
	{
	}

	public class BasicsSettings : MonoBehaviour
	{
	}

	public class ChannelMixerSettings : MonoBehaviour
	{
		public int currentChannel;
	}

	public class CurvesSettings : MonoBehaviour
	{
	}

	public class ColorGradingPrecision : MonoBehaviour
	{
	}

	public class ColorGradingSettings : MonoBehaviour
	{
		public bool useDithering;
		public bool showDebug;
	}

	public class Pass : MonoBehaviour
	{
	}

}