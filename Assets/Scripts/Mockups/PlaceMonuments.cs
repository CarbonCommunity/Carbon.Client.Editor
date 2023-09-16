using UnityEngine;

public class PlaceMonuments : MonoBehaviour
{
	public int TargetCount;
	public int MinDistanceSameType;
	public int MinDistanceDifferentType;
	public int MinWorldSize;
	public bool NexusOnly;
	public bool RunOnCache;

	public class SpawnInfo : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
		public UnityEngine.Vector3 scale;
		public bool dungeonEntrance;
		public UnityEngine.Vector3 dungeonEntrancePos;
	}

	public class DistanceInfo : MonoBehaviour
	{
	}

	public class DistanceMode : MonoBehaviour
	{
	}

}