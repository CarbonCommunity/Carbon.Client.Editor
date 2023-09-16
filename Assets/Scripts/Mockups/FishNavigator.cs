using UnityEngine;

public class FishNavigator : MonoBehaviour
{
	public bool CanNavigateMounted;
	public bool CanUseNavMesh;
	public bool CanUseAStar;
	public bool CanUseBaseNav;
	public bool CanUseCustomNav;
	public float StoppingDistance;
	public bool TriggerStuckEvent;
	public float StuckDistance;
	public float Speed;
	public float Acceleration;
	public float TurnSpeed;
	public bool FaceMoveTowardsTarget;
	public float SlowestSpeedFraction;
	public float SlowSpeedFraction;
	public float NormalSpeedFraction;
	public float FastSpeedFraction;
	public float LowHealthSpeedReductionTriggerFraction;
	public float LowHealthMaxSpeedFraction;
	public float SwimmingSpeedMultiplier;
	public float BestMovementPointMaxDistance;
	public float BestCoverPointMaxDistance;
	public float BestRoamPointMaxDistance;
	public float MaxRoamDistanceFromHome;
	public float MaxWaterDepth;
	public bool SpeedBasedAvoidancePriority;
	public int defaultAreaMask;
	public bool UseBiomePreference;
	public bool IsOnNavMeshLink;
	public bool Moving;

}