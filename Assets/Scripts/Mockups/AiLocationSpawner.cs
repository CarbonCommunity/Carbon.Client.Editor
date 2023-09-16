using UnityEngine;

public class AiLocationSpawner : MonoBehaviour
{
	public bool IsMainSpawner;
	public float chance;
	public int defaultMaxPopulation;
	public int defaultNumToSpawnPerTickMax;
	public int defaultNumToSpawnPerTickMin;
	public int maxPopulation;
	public int numToSpawnPerTickMin;
	public int numToSpawnPerTickMax;
	public float respawnDelayMin;
	public float respawnDelayMax;
	public bool wantsInitialSpawn;
	public bool temporary;
	public bool forceInitialSpawn;
	public bool preventDuplicates;
	public bool isSpawnerActive;

	public class SquadSpawnerLocation : MonoBehaviour
	{
	}

}