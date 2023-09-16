using UnityEngine;

public class Buoyancy : MonoBehaviour
{
	public float buoyancyScale;
	public bool doEffects;
	public float flowMovementScale;
	public float requiredSubmergedFraction;
	public bool useUnderwaterDrag;
	public float underwaterDrag;
	public float flatWaterLerp;
	public float submergedFraction;

	public class WhenDisabled : MonoBehaviour
	{
	}

}