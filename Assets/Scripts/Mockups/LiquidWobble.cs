using UnityEngine;

public class LiquidWobble : MonoBehaviour
{
	public UnityEngine.Vector3 lastPos;
	public UnityEngine.Vector3 velocity;
	public UnityEngine.Vector3 lastRot;
	public UnityEngine.Vector3 angularVelocity;
	public float CurrentWaterLevelFraction;
	public float MinWaterLevel;
	public float MaxWaterLevel;
	public float MaxWobble;
	public float WobbleSpeed;
	public float Recovery;
	public float wobbleAmountX;
	public float wobbleAmountZ;
	public float wobbleAmountToAddX;
	public float wobbleAmountToAddZ;
	public float pulse;
	public float time;
	public float turbulence;

}