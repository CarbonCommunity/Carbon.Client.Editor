using UnityEngine;

public class ItemIcon : MonoBehaviour
{
	public float unoccupiedAlpha;
	public int slotOffset;
	public int slot;
	public bool setSlotFromSiblingIndex;
	public bool allowSelection;
	public bool allowDropping;
	public bool allowMove;
	public bool showCountDropShadow;
	public bool invalidSlot;
	public bool queuedForLooting;
	public float queuedLootAtTime;
	public bool visible;
	public bool hovering;
	public bool isSelected;

	public class DragInfo : MonoBehaviour
	{
		public int amount;
		public bool canDrop;
	}

}