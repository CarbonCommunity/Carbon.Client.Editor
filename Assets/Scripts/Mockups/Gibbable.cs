using UnityEngine;

public class Gibbable : MonoBehaviour
{
	public bool copyMaterialBlock;
	public bool applyDamageTexture;
	public bool spawnFxPrefab;
	public bool important;
	public bool useContinuousCollision;
	public float explodeScale;
	public float scaleOverride;
	public int uniqueId;
	public bool isConditional;
	public UnityEngine.Bounds effectBounds;
	public bool UsePerGibWaterCheck;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

	public class OverrideMesh : MonoBehaviour
	{
	}

	public class ColliderType : MonoBehaviour
	{
	}

	public class ParentingType : MonoBehaviour
	{
	}

	public class BoundsEffectType : MonoBehaviour
	{
	}

	public class GibMesh : MonoBehaviour
	{
		public UnityEngine.Vector3 localPosition;
	}

}