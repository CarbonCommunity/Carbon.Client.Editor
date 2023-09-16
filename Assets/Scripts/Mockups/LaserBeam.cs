using UnityEngine;

public class LaserBeam : MonoBehaviour
{
	public float scrollSpeed;
	public UnityEngine.Vector2 scrollDir;
	public float maxDistance;
	public float stillBlendFactor;
	public float movementBlendFactor;
	public float movementThreshhold;
	public bool isFirstPerson;
	public bool scaleDotByDistance;
	public float dotBaseScale;
	public float dotMaxScale;
	public float cachedDotDistance;
	public float aimToBarrelBlendFrac;

	public class LaserBeamWorkQueue : MonoBehaviour
	{
		public long warnTime;
		public int currentIndex;
		public int listLength;
	}

}