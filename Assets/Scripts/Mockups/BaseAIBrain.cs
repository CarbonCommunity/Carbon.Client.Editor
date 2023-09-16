using UnityEngine;

public class BaseAIBrain : MonoBehaviour
{
	public bool SendClientCurrentState;
	public bool UseQueuedMovementUpdates;
	public bool AllowedToSleep;
	public float SenseRange;
	public float AttackRangeMultiplier;
	public float TargetLostRange;
	public float VisionCone;
	public bool CheckVisionCone;
	public bool CheckLOS;
	public bool IgnoreNonVisionSneakers;
	public float IgnoreSneakersMaxDistance;
	public float IgnoreNonVisionMaxDistance;
	public float ListenRange;
	public bool HostileTargetsOnly;
	public bool IgnoreSafeZonePlayers;
	public int MaxGroupSize;
	public float MemoryDuration;
	public bool RefreshKnownLOS;
	public bool CanBeBlinded;
	public float BlindDurationMultiplier;
	public UnityEngine.Vector3 mainInterestPoint;
	public bool UseAIDesign;
	public bool Pet;
	public bool CanUseHealingItems;
	public float HealChance;
	public float HealBelowHealthFraction;

	public class BasicAIState : MonoBehaviour
	{
	}

}