using UnityEngine;

public class ServerBrowserList : MonoBehaviour
{
	public bool startActive;
	public int refreshOrder;
	public bool UseOfficialServers;
	public bool hideOfficialServers;
	public bool excludeEmptyServersUsingQuery;
	public bool alwaysIncludeEmptyServers;
	public bool clampPlayerCountsToTrustedValues;
	public bool shouldShowSecureServers;
	public bool showFull;
	public bool showEmpty;
	public bool isDirty;

	public class Rules : MonoBehaviour
	{
	}

	public class QueryType : MonoBehaviour
	{
	}

	public class ServerKeyvalues : MonoBehaviour
	{
	}

}