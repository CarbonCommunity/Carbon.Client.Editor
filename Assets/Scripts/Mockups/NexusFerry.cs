using UnityEngine;

public class NexusFerry : MonoBehaviour
{
	public float TravelVelocity;
	public float ApproachVelocity;
	public float StoppingVelocity;
	public float AccelerationSpeed;
	public float TurnSpeed;
	public float VelocityPreservationOnTurn;
	public float TargetDistanceThreshold;
	public float departureHornLeadTime;
	public int CastSweepDegrees;
	public float CastSweepNoise;
	public float CastInterval;
	public float CastHitProtection;
	public int PathLookahead;
	public int PathLookaheadThreshold;
	public long _timestamp;
	public int _scheduleIndex;
	public bool _isRetiring;
	public int _nextScheduleIndex;
	public bool _departureHornPlayed;
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

	public class State : MonoBehaviour
	{
	}

}