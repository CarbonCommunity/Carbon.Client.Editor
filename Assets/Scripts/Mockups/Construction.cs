using UnityEngine;

public class Construction : MonoBehaviour
{
	public bool canBypassBuildingPermission;
	public bool canRotateBeforePlacement;
	public bool canRotateAfterPlacement;
	public bool checkVolumeOnRotate;
	public bool checkVolumeOnUpgrade;
	public bool canPlaceAtMaxDistance;
	public bool placeOnWater;
	public UnityEngine.Vector3 rotationAmount;
	public UnityEngine.Vector3 applyStartingRotation;
	public bool enforceLineOfSightCheckAgainstParentEntity;
	public float healthMultiplier;
	public float costMultiplier;
	public float maxplaceDistance;
	public UnityEngine.Bounds bounds;
	public bool isBuildingPrivilege;
	public bool isSleepingBag;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

	public class Grade : MonoBehaviour
	{
		public float maxHealth;
	}

	public class MeshPlaceholder : MonoBehaviour
	{
	}

	public class Target : MonoBehaviour
	{
		public bool valid;
		public bool onTerrain;
		public UnityEngine.Vector3 position;
		public UnityEngine.Vector3 normal;
		public UnityEngine.Vector3 rotation;
		public bool inBuildingPrivilege;
	}

	public class Placement : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
	}

}