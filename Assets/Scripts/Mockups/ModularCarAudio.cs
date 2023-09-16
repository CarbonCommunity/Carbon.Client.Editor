using UnityEngine;

public class ModularCarAudio : MonoBehaviour
{
	public bool showDebug;
	public float skidMinSlip;
	public float skidMaxSlip;
	public float movementStartStopMinTimeBetweenSounds;
	public float movementRattleMaxSpeed;
	public float movementRattleMaxAngSpeed;
	public float movementRattleIdleGain;
	public float suspensionLurchMinExtensionDelta;
	public float suspensionLurchMinTimeBetweenSounds;
	public float skidRatio;
	public bool wasStationary;
	public float lastMovementStartSoundPlayed;
	public float lastMovementStopSoundPlayed;
	public float noMovementCount;
	public float wheelRatioMultiplier;
	public float waterSoundsMaxSpeed;
	public bool wasInWater;
	public float engineRpmDamp;
	public float wheelsRpm;
	public int gear;
	public int prevGear;

}