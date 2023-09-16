using UnityEngine;

public class TakeCollisionDamage : MonoBehaviour
{
	public float minDamage;
	public float maxDamage;
	public float forceForAnyDamage;
	public float forceForMaxDamage;
	public float velocityRestorePercent;
	public bool IsServer;
	public bool IsClient;

}