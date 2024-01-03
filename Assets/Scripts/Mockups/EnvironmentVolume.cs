using UnityEngine;

public class EnvironmentVolume : MonoBehaviour
{
	public UnityEngine.Vector3 Center;
	public UnityEngine.Vector3 Size;

	public EnvironmentType Type = (EnvironmentType)((ulong)1L);

	public enum EnvironmentType
	{
		Underground = 1,
		Building = 2,
		Outdoor = 4,
		Elevator = 8,
		PlayerConstruction = 16,
		TrainTunnels = 32,
		UnderwaterLab = 64,
		Submarine = 128,
		BuildingDark = 256,
		BuildingVeryDark = 512,
		NoSunlight = 1024
	}
}
