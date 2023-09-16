using UnityEngine;

public class LiquidWeaponEffects : MonoBehaviour
{
	public float MinPressureSpeed;
	public float MaxPressureSpeed;
	public UnityEngine.Vector2 StreamSize;
	public float MinPressureInnerSpeed;
	public float MaxPressureInnerSpeed;
	public UnityEngine.Vector2 InnerStreamSize;
	public bool UseImpactSplashEffect;
	public float ImpactSplashEffectInterval;
	public float FillSpeed;
	public float maxRange;
	public float currentRange;
	public float pressure;
	public float nextSplashTime;
	public float targetWaterLevel;
	public bool firstPersonSounds;
	public bool impactStartPlayed;
	public bool lastImpactHit;
	public UnityEngine.Vector3 lastImpactPosition;
	public bool emitting;

}