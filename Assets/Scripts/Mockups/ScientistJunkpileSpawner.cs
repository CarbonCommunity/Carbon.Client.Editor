using UnityEngine;

public class ScientistJunkpileSpawner : MonoBehaviour
{
	public int MaxPopulation;
	public bool InitialSpawn;
	public float MinRespawnTimeMinutes;
	public float MaxRespawnTimeMinutes;
	public float MovementRadius;
	public bool ReducedLongRangeAccuracy;
	public float SpawnBaseChance;

	public class JunkpileType : MonoBehaviour
	{
	}

}