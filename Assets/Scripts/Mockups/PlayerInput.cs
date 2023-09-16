using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public bool hadInputBuffer;
	public UnityEngine.Vector3 bodyAngles;
	public UnityEngine.Vector3 headAngles;
	public UnityEngine.Vector3 recoilAngles;
	public UnityEngine.Vector2 viewDelta;
	public float headLerp;
	public int mouseWheelUp;
	public int mouseWheelDn;
	public bool autorun;
	public bool toggleDuck;
	public bool toggleAds;
	public UnityEngine.Vector3 pendingMouseDelta;
	public UnityEngine.Vector3 offsetAngles;
	public int ignoredButtons;
	public bool hasKeyFocus;
	public bool hasOnlyPartialKeyInput;

}