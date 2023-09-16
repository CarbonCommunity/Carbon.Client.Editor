using UnityEngine;

public class PlaceMonumentsOffshore : MonoBehaviour
{
	public int TargetCount;
	public int MinDistanceFromTerrain;
	public int MaxDistanceFromTerrain;
	public int DistanceBetweenMonuments;
	public int MinWorldSize;
	public bool RunOnCache;

	public class SpawnInfo : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
		public UnityEngine.Vector3 scale;
	}

}