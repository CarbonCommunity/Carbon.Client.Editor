using UnityEngine;

public class PlayerWalkMovement : MonoBehaviour
{
	public float capsuleHeight;
	public float capsuleCenter;
	public float capsuleHeightDucked;
	public float capsuleCenterDucked;
	public float capsuleHeightCrawling;
	public float capsuleCenterCrawling;
	public float gravityTestRadius;
	public float gravityMultiplier;
	public float gravityMultiplierSwimming;
	public float maxAngleWalking;
	public float maxAngleClimbing;
	public float maxAngleSliding;
	public float maxStepHeight;
	public float maxVelocity;
	public float groundAngle;
	public float groundAngleNew;
	public float groundTime;
	public float jumpTime;
	public float landTime;
	public UnityEngine.Vector3 previousPosition;
	public UnityEngine.Vector3 previousVelocity;
	public UnityEngine.Vector3 previousInheritedVelocity;
	public UnityEngine.Vector3 groundNormal;
	public UnityEngine.Vector3 groundNormalNew;
	public UnityEngine.Vector3 groundVelocity;
	public UnityEngine.Vector3 groundVelocityNew;
	public float nextSprintTime;
	public float lastSprintTime;
	public bool sprintForced;
	public bool grounded;
	public bool climbing;
	public bool sliding;
	public bool swimming;
	public bool wasSwimming;
	public bool jumping;
	public bool wasJumping;
	public bool falling;
	public bool wasFalling;
	public bool flying;
	public bool wasFlying;
	public float forcedDuckDelta;
	public bool adminCheat;
	public float adminSpeed;
	public float lastTeleportedTime;
	public bool IsRunning;
	public bool IsDucked;
	public bool IsCrawling;
	public bool IsGrounded;
	public bool RecentlyTeleported;

}