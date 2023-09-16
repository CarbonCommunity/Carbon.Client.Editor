using UnityEngine;

public class TriggerHurtNotChild : MonoBehaviour
{
	public float DamagePerSecond;
	public float DamageTickRate;
	public float DamageDelay;
	public bool ignoreNPC;
	public float npcMultiplier;
	public float resourceMultiplier;
	public bool triggerHitImpacts;
	public bool RequireUpAxis;
	public bool UseSourceEntityDamageMultiplier;
	public bool ignoreAllVehicleMounted;
	public float activationDelay;
	public bool HasAnyContents;
	public bool HasAnyEntityContents;

	public class IHurtTriggerUser : MonoBehaviour
	{
	}

}