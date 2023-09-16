using UnityEngine;

public class GameStat : MonoBehaviour
{
	public float refreshTime;
	public long globalValue;
	public long localValue;
	public float secondsSinceRefresh;
	public float secondsUntilUpdate;
	public float secondsUntilChange;

	public class Stat : MonoBehaviour
	{
	}

}