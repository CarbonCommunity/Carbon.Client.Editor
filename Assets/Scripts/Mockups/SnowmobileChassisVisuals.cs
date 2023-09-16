using UnityEngine;

public class SnowmobileChassisVisuals : MonoBehaviour
{
	public float treadSpeedMultiplier;
	public bool flipRightSkiExtension;
	public float skiVisualAdjust;
	public float treadVisualAdjust;
	public float skiVisualMaxExtension;
	public float treadVisualMaxExtension;
	public float wheelSizeVisualMultiplier;
	public float treadExtension;
	public float treadPrevExtension;
	public float treadRotation;
	public int animNeedleShakeIndex;
	public int animEngineOnIndex;
	public float steerPercent;
	public float prevSteer;
	public bool isStopped;

	public class TreadRenderer : MonoBehaviour
	{
		public int materialIndex;
	}

}