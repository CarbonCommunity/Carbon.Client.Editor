using UnityEngine;

public class ChangeSignText : MonoBehaviour
{
	public int currentFrame;
	public bool isClosing;

	public class UndoBuffer : MonoBehaviour
	{
		public int undoIndex;
		public int undoSteps;
		public int CurrentSlot;
		public bool IsUndoAvailable;
		public bool IsRedoAvailable;
	}

}