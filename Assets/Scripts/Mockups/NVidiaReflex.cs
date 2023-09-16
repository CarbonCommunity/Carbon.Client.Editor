using UnityEngine;

public class NVidiaReflex : MonoBehaviour
{
	public uint previousIntervalUs;
	public int previousMode;
	public bool hasSimulationStarted;
	public bool prevUseMarkersToOptimize;
	public int intervalUs;

	public class Mode : MonoBehaviour
	{
	}

	public class NvReflex_LATENCY_MARKER_TYPE : MonoBehaviour
	{
	}

	public class NvReflex_Status : MonoBehaviour
	{
	}

	public class NvReflex_FrameReport : MonoBehaviour
	{
	}

	public class NvReflex_LATENCY_RESULT_PARAMS : MonoBehaviour
	{
	}

	public class NvReflex_GET_SLEEP_STATUS_PARAMS : MonoBehaviour
	{
	}

}