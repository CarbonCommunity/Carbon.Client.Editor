using UnityEngine;

public class SnowballGunProjectile : MonoBehaviour
{
	public float OverrideEffectScale;
	public UnityEngine.Vector3 initialVelocity;
	public float drag;
	public float gravityModifier;
	public float thickness;
	public float initialDistance;
	public bool remainInWorld;
	public float stickProbability;
	public float breakProbability;
	public float conditionLoss;
	public float ricochetChance;
	public float penetrationPower;
	public float waterIntegrityLoss;
	public bool createDecals;
	public bool doDefaultHitEffects;
	public float flybySoundDistance;
	public float closeFlybyDistance;
	public float tumbleSpeed;
	public UnityEngine.Vector3 tumbleAxis;
	public UnityEngine.Vector3 swimScale;
	public UnityEngine.Vector3 swimSpeed;
	public int projectileID;
	public int seed;
	public bool clientsideEffect;
	public bool clientsideAttack;
	public float integrity;
	public float maxDistance;
	public bool invisible;
	public UnityEngine.Vector3 currentVelocity;
	public UnityEngine.Vector3 currentPosition;
	public float traveledDistance;
	public float traveledTime;
	public float launchTime;
	public UnityEngine.Vector3 sentPosition;
	public UnityEngine.Vector3 previousPosition;
	public UnityEngine.Vector3 previousVelocity;
	public float previousTraveledTime;
	public bool isUnderwater;
	public bool isRicochet;
	public bool isRetiring;
	public bool flybyPlayed;
	public bool wasFacingPlayer;
	public float swimRandom;
	public bool isAuthoritative;
	public bool isAlive;

}