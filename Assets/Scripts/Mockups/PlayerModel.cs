using UnityEngine;

public class PlayerModel : MonoBehaviour
{
	public UnityEngine.Vector3 rightHandTarget;
	public UnityEngine.Vector3 leftHandTargetPosition;
	public UnityEngine.Vector3 rightHandTargetPosition;
	public float steeringTargetDegrees;
	public UnityEngine.Vector3 rightFootTargetPosition;
	public UnityEngine.Vector3 leftFootTargetPosition;
	public float voiceVolume;
	public float skinColor;
	public float skinNumber;
	public float meshNumber;
	public float hairNumber;
	public int skinType;
	public bool showSash;
	public int tempPoseType;
	public uint underwearSkin;
	public UnityEngine.Vector3 position;
	public UnityEngine.Vector3 velocity;
	public UnityEngine.Vector3 speedOverride;
	public UnityEngine.Vector3 newVelocity;
	public float fallingTime;
	public UnityEngine.Vector3 smoothLeftFootIK;
	public UnityEngine.Vector3 smoothRightFootIK;
	public bool drawShadowOnly;
	public bool isIncapacitated;
	public uint flinchLocation;
	public bool visible;
	public bool animatorNeedsWarmup;
	public bool isLocalPlayer;
	public bool InGesture;
	public bool InCinematic;
	public float holdTypeLock;
	public bool hasHeldEntity;
	public bool wasMountedRightAim;
	public int cachedMask;
	public int cachedConstructionMask;
	public bool wasCrawling;
	public float mountedSpineLookWeight;
	public float mountedAnimSpeed;
	public bool preserveBones;
	public UnityEngine.Vector3 cachedLeftFootPos;
	public UnityEngine.Vector3 cachedLeftFootNormal;
	public UnityEngine.Vector3 cachedRightFootPos;
	public UnityEngine.Vector3 cachedRightFootNormal;
	public float _smoothAimWeight;
	public float _smoothVelocity;
	public UnityEngine.Vector3 _smoothlookAngle;
	public bool allowMountedHeadLook;
	public float overrideLeftHandIkWeight;
	public float overrideRightHandIkWeight;
	public UnityEngine.Vector3 smoothLookDir;
	public UnityEngine.Vector3 lastSafeLookDir;
	public float extraLeanBack;
	public float timeInArmsMode;
	public bool IsFemale;
	public bool GestureAllowsSpineMovement;
	public bool GestureAllowsRootMotion;
	public bool IsFirstPerson;
	public bool ShouldDoLegs;
	public bool ShouldShowHands;

	public class MountPoses : MonoBehaviour
	{
	}

	public class ReactionDir : MonoBehaviour
	{
	}

	public class SwapType : MonoBehaviour
	{
	}

}