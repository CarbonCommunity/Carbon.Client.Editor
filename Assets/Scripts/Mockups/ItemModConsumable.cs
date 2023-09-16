using UnityEngine;

public class ItemModConsumable : MonoBehaviour
{
	public int amountToConsume;
	public float conditionFractionToLose;

	public class ConsumableEffect : MonoBehaviour
	{
		public float amount;
		public float time;
		public float onlyIfHealthLessThan;
	}

}