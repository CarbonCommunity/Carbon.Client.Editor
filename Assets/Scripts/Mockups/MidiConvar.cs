using UnityEngine;

public class MidiConvar : MonoBehaviour
{

	public class NoteType : MonoBehaviour
	{
	}

	public class KnobBinding : MonoBehaviour
	{
		public int knobNumber;
		public float minValue;
		public float maxValue;
		public int channel;
		public bool relative;
	}

	public class NoteBinding : MonoBehaviour
	{
		public int noteNumber;
		public int channel;
		public bool cycled;
		public int cycleIndex;
	}

	public class SavedBindings : MonoBehaviour
	{
	}

}