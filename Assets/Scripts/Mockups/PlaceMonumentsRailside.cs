using UnityEngine;

public class PlaceMonumentsRailside : MonoBehaviour
{
	public int TargetCount;
	public int PositionOffset;
	public int TangentInterval;
	public int MinDistanceSameType;
	public int MinDistanceDifferentType;
	public int MinWorldSize;
	public bool RunOnCache;

	public class SpawnInfo : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
		public UnityEngine.Vector3 scale;
	}

	public class SpawnInfoGroup : MonoBehaviour
	{
		public bool processed;
	}

	public class DistanceInfo : MonoBehaviour
	{
	}

	public class DistanceMode : MonoBehaviour
	{
	}

}