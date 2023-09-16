using UnityEngine;

public class SingleSpawn : MonoBehaviour
{
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

}