using UnityEngine;

public class ScientistSpawner : MonoBehaviour
{
	public bool Mobile;
	public bool NeverMove;
	public bool SpawnHostile;
	public bool OnlyAggroMarkedTargets;
	public bool IsPeacekeeper;
	public bool IsBandit;
	public bool IsMilitaryTunnelLab;
	public UnityEngine.Vector2 RadioEffectRepeatRange;
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