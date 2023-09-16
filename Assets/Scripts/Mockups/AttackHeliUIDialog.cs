using UnityEngine;

public class AttackHeliUIDialog : MonoBehaviour
{
	public float zoomIndicatorMinY;
	public float zoomIndicatorMaxY;
	public float positionBoxXMult;
	public float positionBoxYMult;
	public UnityEngine.Vector3 boxZeroPos;
	public UnityEngine.Vector2 middleAnchor;
	public float prevHealth;
	public float compassFloatOrig;
	public int itemIDRocketHV;
	public int itemIDRocketIncen;
	public float defaultCrosshairAlpha;
	public float defaultNACrosshairAlpha;
	public bool isClosing;

	public class RocketType : MonoBehaviour
	{
	}

}