using UnityEngine;

public class InstrumentIKController : MonoBehaviour
{
	public UnityEngine.Vector3 HitRotationVector;
	public float HandHeightMultiplier;
	public float HandMoveLerpSpeed;
	public bool DebugHitRotation;
	public float NoteHitTime;
	public float BodyLookWeight;
	public float HeadLookWeight;
	public float LookWeightLimit;
	public bool HoldHandsAtPlay;
	public int currentLeftHandTarget;
	public float leftHandTargetNoteTime;
	public int currentRightHandTarget;
	public float rightHandTargetNoteTime;
	public int currentRightFootTarget;
	public float rightFootTargetNoteTime;
	public UnityEngine.Vector3 leftHandIkPos;
	public UnityEngine.Vector3 rightHandIkPos;
	public UnityEngine.Vector3 rightFootIkPos;
	public float totalHandAnimTime;
	public float lastSetLeftHandTime;
	public float lastSetRightHandTime;
	public float lastSetRightFootTime;

}