using UnityEngine;

public class CameraMan : MonoBehaviour
{
	public bool OnlyControlWhenCursorHidden;
	public bool NeedBothMouseButtonsToZoom;
	public float LookSensitivity;
	public float MoveSpeed;
	public int _guide;
	public bool startCulling;
	public bool hasSetFov;
	public float targetDistance;
	public float targetDistancePrev;
	public UnityEngine.Vector3 wishMove;
	public UnityEngine.Vector3 view;
	public UnityEngine.Vector3 viewPrev;
	public UnityEngine.Vector3 velocity;
	public int Guide;
	public float Fov;

	public class CameraState : MonoBehaviour
	{
	}

	public class MovementType : MonoBehaviour
	{
	}

}