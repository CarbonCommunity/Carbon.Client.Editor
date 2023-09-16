using UnityEngine;

public class PlaceCliffs : MonoBehaviour
{
	public int RetryMultiplier;
	public int CutoffSlope;
	public float MinScale;
	public float MaxScale;
	public bool RunOnCache;

	public class CliffPlacement : MonoBehaviour
	{
		public int count;
		public int score;
		public UnityEngine.Vector3 pos;
		public UnityEngine.Vector3 scale;
	}

}