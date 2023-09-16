using UnityEngine;

public class TorchWeapon : MonoBehaviour
{
	public float fuelTickAmount;
	public bool ExtinguishUnderwater;
	public bool UseTurnOnOffAnimations;
	public bool triggerOn;
	public bool triggerOff;
	public bool specVmWasOn;
	public float maxDistance;
	public float attackRadius;
	public bool isAutomatic;
	public bool blockSprintOnAttack;
	public bool canUntieCrates;
	public bool useStandardHitEffects;
	public float aiStrikeDelay;
	public float heartStress;
	public bool throwReady;
	public bool canThrowAsProjectile;
	public bool canAiHearIt;
	public bool onlyThrowAsProjectile;
	public bool CanAttack;
	public bool CanThrow;
	public float deployDelay;
	public float repeatDelay;
	public float animationDelay;
	public float effectiveRange;
	public float npcDamageScale;
	public float attackLengthMin;
	public float attackLengthMax;
	public float attackSpacing;
	public float aiAimSwayOffset;
	public float aiAimCone;
	public bool aiOnlyInRange;
	public float CloseRangeAddition;
	public float MediumRangeAddition;
	public float LongRangeAddition;
	public bool CanUseAtMediumRange;
	public bool CanUseAtLongRange;
	public float recoilCompDelayOverride;
	public bool wantsRecoilComp;
	public float nextAttackTime;
	public float lastTickTime;
	public float nextTickTime;
	public float timeSinceDeploy;
	public float lastRecoilCompTime;
	public UnityEngine.Vector3 startAimingDirection;
	public bool wasDoingRecoilComp;
	public UnityEngine.Vector3 reductionSpeed;
	public bool UsingInfiniteAmmoCheat;
	public float NextAttackTime;
	public bool isDeployed;
	public float nextExamineTime;
	public bool isBuildingTool;
	public float hostileScore;
	public UnityEngine.Vector3 FirstPersonArmOffset;
	public UnityEngine.Vector3 FirstPersonArmRotation;
	public float FirstPersonRotationStrength;
	public UnityEngine.Vector3 punchAdded;
	public float lastPunchTime;
	public bool hostile;
	public UnityEngine.Bounds bounds;
	public bool enableSaving;
	public bool syncPosition;
	public uint parentBone;
	public ulong skinID;
	public bool HasBrain;
	public uint broadcastProtocol;
	public bool linkedToNeighbours;
	public bool isVisible;
	public bool isAnimatorVisible;
	public bool isShadowVisible;
	public float RealisticMass;
	public bool IsNpc;
	public bool HasDisabledRenderers;
	public uint prefabID;
	public bool globalBroadcast;
	public bool globalBuildingBlock;
	public bool canTriggerParent;
	public bool isServer;
	public bool isClient;

}