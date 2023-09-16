using UnityEngine;

public class BaseGameMode : MonoBehaviour
{
	public bool globalChat;
	public bool localChat;
	public bool teamSystem;
	public bool safeZone;
	public bool ingameMap;
	public bool compass;
	public bool contactSystem;
	public bool crawling;
	public bool rustPlus;
	public bool wipeBpsOnProtocol;
	public int maximumSleepingBags;
	public bool returnValidCombatlog;
	public bool missionSystem;
	public bool mlrs;
	public float matchDuration;
	public float warmupDuration;
	public float timeBetweenMatches;
	public int minPlayersToStart;
	public bool useCustomSpawns;
	public int numScoreForVictory;
	public float warmupStartTime;
	public float matchStartTime;
	public float matchEndTime;
	public bool permanent;
	public bool limitTeamAuths;
	public bool allowSleeping;
	public bool allowWounding;
	public bool allowBleeding;
	public bool allowTemperature;
	public bool quickRespawn;
	public bool quickDeploy;
	public float respawnDelayOverride;
	public float startHealthOverride;
	public float autoHealDelay;
	public float autoHealDuration;
	public bool hasKillFeed;
	public bool allowPings;
	public bool useStaticLoadoutPerPlayer;
	public bool topUpMagazines;
	public bool sendKillNotifications;
	public bool wasInWarmup;
	public bool wasMatchOver;
	public bool wasMatchActive;
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

	public class ResearchCostResult : MonoBehaviour
	{
	}

	public class GameModeTeam : MonoBehaviour
	{
	}

}