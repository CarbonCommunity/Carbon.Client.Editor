using UnityEngine;

public class SellOrderEntry : MonoBehaviour
{
	public bool dirty;
	public int minMultiplier;
	public bool merchIsBP;
	public bool currencyIsBP;
	public int merchandiseSellSize;
	public int currencyAmountPerItem;
	public int index;
	public int numInStock;
	public float itemCondition;
	public float itemConditionMax;
	public int itemInstanceInt;

	public class CachedSellOrderState : MonoBehaviour
	{
	}

}