using UnityEngine;

public class ItemDefinition : MonoBehaviour
{
	public int itemid;
	public int maxDraggable;
	public int stackable;
	public bool quickDespawn;
	public bool spawnAsBlueprint;
	public bool hidden;
	public int craftingStackable;
	public bool isWearable;
	public bool HasSkins;

	public class Condition : MonoBehaviour
	{
		public float max;
		public bool repairable;
		public bool maintainMaxCondition;
		public bool ovenCondition;
	}

	public class OverrideWorldModel : MonoBehaviour
	{
		public int minStackSize;
	}

	public class RedirectVendingBehaviour : MonoBehaviour
	{
	}

	public class Flag : MonoBehaviour
	{
	}

	public class AmountType : MonoBehaviour
	{
	}

}