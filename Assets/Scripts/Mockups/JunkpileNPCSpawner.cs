using UnityEngine;

public class JunkpileNPCSpawner : MonoBehaviour
{
	public bool UseSpawnChance;
	public int AdditionalLOSBlockingLayer;
	public bool shouldFillOnSpawn;
	public bool UseStatModifiers;
	public float SenseRange;
	public bool CheckLOS;
	public float TargetLostRange;
	public float AttackRangeMultiplier;
	public float ListenRange;
	public float CanUseHealingItemsChance;
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