using UnityEngine;

public class WindZoneExManager : MonoBehaviour
{
	public float maxAccumMain;
	public float maxAccumTurbulence;
	public float globalMainScale;
	public float globalTurbulenceScale;

	public class TestMode : MonoBehaviour
	{
	}

	public class CurrentZoneEntry : MonoBehaviour
	{
		public float distanceSqr;
	}

}