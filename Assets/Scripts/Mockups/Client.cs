using UnityEngine;

public class Client : MonoBehaviour
{
	public bool connectionRetry;
	public float LastConfigSaveTime;
	public bool backgroundCapApplied;
	public bool StatsEnabled;
	public bool HasFrameRateCapApplied;

	public class ConnectionProtocol : MonoBehaviour
	{
	}

	public class ProcessAccessFlags : MonoBehaviour
	{
	}

}