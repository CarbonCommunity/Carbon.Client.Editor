using UnityEngine;

public class PostProcessLayer : MonoBehaviour
{
	public float prevRenderScale;
	public uint prevScreenWidth;
	public uint prevScreenHeight;
	public float prevUpdateTime;
	public bool screenshotMode;
	public bool firstDLSSPass;
	public bool stopNaNPropagation;
	public bool finalBlitToCameraTarget;
	public bool supportsIntermediateFormat;
	public bool m_ShowToolkit;
	public bool m_ShowCustomSorter;
	public bool breakBeforeColorGrading;
	public bool m_SettingsUpdateNeeded;
	public bool m_IsRenderingInSceneView;
	public bool m_NaNKilled;
	public bool ScreenshotMode;
	public uint ScreenWidth;
	public uint ScreenHeight;
	public uint ScaledScreenWidth;
	public uint ScaledScreenHeight;

	public class ScalingMode : MonoBehaviour
	{
	}

	public class Antialiasing : MonoBehaviour
	{
	}

	public class SerializedBundleRef : MonoBehaviour
	{
	}

}