using UnityEngine;

public class Climate : MonoBehaviour
{
	public float BlendingSpeed;
	public float FogMultiplier;
	public float FogDarknessDistance;
	public bool DebugLUTBlending;
	public bool FogLerpEnabled;

	public class ClimateParameters : MonoBehaviour
	{
	}

	public class WeatherParameters : MonoBehaviour
	{
		public float ClearChance;
		public float DustChance;
		public float FogChance;
		public float OvercastChance;
		public float StormChance;
		public float RainChance;
	}

	public class Float4 : MonoBehaviour
	{
		public float Dawn;
		public float Noon;
		public float Dusk;
		public float Night;
	}

	public class Color4 : MonoBehaviour
	{
	}

	public class Texture2D4 : MonoBehaviour
	{
	}

}