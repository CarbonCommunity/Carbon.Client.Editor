using UnityEngine;

public class TugboatSounds : MonoBehaviour
{
	public float roughHalfWidth;
	public float roughHalfLength;
	public float soundCullDistanceSq;
	public float engineGainChangeRate;
	public float enginePitchChangeRate;
	public float waterMovementGainChangeRate;
	public UnityEngine.Vector3 sideSoundLineStern;
	public UnityEngine.Vector3 sideSoundLineBow;
	public float hullGroanCooldown;
	public float lastHullGroan;
	public float chainRattleCooldown;
	public float chainRattleAngleDeltaThreshold;
	public float lastChainRattle;
	public bool engineOn;
	public bool throttleOn;
	public bool inWater;
	public UnityEngine.Vector3 lastPosition;
	public float lastUpAngle;
	public float lastUpAngleDelta;
	public UnityEngine.Vector3 velocity;
	public float speed;
	public bool wasEngineOn;
	public bool inBridge;
	public bool inBelowDeck;
	public bool inInterior;

}