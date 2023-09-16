using UnityEngine;

public class UIPlayerPreviewControls : MonoBehaviour
{
	public float RotationSpeed;
	public float RotationLerpSpeed;
	public float RotationStopLerpSpeed;
	public bool rotating;
	public bool pointerInControlArea;
	public float rotationVelocity;
	public float horizRotationPerc;
	public float startingRotation;
	public UnityEngine.Vector3 dragInputPos;
	public UnityEngine.Vector3 currentDragInputPos;
	public UnityEngine.Vector3 rotation;
	public bool showInventoryPlayer;

}