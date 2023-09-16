using UnityEngine;

public class NpcWalkAnimation : MonoBehaviour
{
	public UnityEngine.Vector3 HipFudge;
	public bool UpdateWalkSpeed;
	public bool UpdateFacingDirection;
	public bool UpdateGroundNormal;
	public bool LaggyAss;
	public bool LookAtTarget;
	public float MaxLaggyAssRotation;
	public float MaxWalkAnimSpeed;
	public bool UseDirectionBlending;
	public bool useTurnPosing;
	public float turnPoseScale;
	public float laggyAssLerpScale;
	public bool skeletonChainInverted;
	public UnityEngine.Vector3 oldPosition;
	public UnityEngine.Vector3 targetUp;
	public UnityEngine.Vector3 targetOffset;
	public UnityEngine.Vector3 lastForward;
	public bool lastGroundAlignHit;
	public float avgTurnDifference;

	public class NPCWalkWorkQueue : MonoBehaviour
	{
		public long warnTime;
		public int currentIndex;
		public int listLength;
	}

}