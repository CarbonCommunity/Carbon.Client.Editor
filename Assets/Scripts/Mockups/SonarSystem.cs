using UnityEngine;

public class SonarSystem : MonoBehaviour
{
	public float range;
	public float maxDepth;
	public float rangeSqr;
	public float sonarAngle;
	public int blipIndex;
	public float scale;
	public float blipSize;
	public UnityEngine.Vector3 ourRefreshHeading;

	public class SonarBlip : MonoBehaviour
	{
	}

}