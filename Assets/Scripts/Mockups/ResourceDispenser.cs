using UnityEngine;

public class ResourceDispenser : MonoBehaviour
{
	public float maxDestroyFractionForFinishBonus;
	public float fractionRemaining;

	public class GatherType : MonoBehaviour
	{
	}

	public class GatherPropertyEntry : MonoBehaviour
	{
		public float gatherDamage;
		public float destroyFraction;
		public float conditionLost;
	}

	public class GatherProperties : MonoBehaviour
	{
	}

}