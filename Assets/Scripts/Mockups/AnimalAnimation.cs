using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
	public bool hasIdleOffset;
	public float lastThinkTime;
	public UnityEngine.Vector3 previousPosition;
	public float previousRotationYaw;
	public bool wasSleeping;

	public class Params : MonoBehaviour
	{
	}

}