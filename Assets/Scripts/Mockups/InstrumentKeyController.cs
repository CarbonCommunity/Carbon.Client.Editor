using UnityEngine;

public class InstrumentKeyController : MonoBehaviour
{
	public float lastAnimationSlotTime;
	public uint overrideAchievementId;
	public bool playedFirstNote;
	public float teamAchievementCheck;
	public bool subscribedToMidi;
	public bool hasSetupBindings;
	public bool sustain;
	public int lastMidiFrame;
	public int midiNotesThisFrame;
	public float recordingStartTime;
	public float playbackElapsedTime;
	public bool RecentlyPlayedNote;
	public bool HeldByLocalPlayer;
	public bool IsPlaying;
	public int CurrentlyPlayingNotes;

	public class IKType : MonoBehaviour
	{
	}

	public class NoteType : MonoBehaviour
	{
	}

	public class InstrumentType : MonoBehaviour
	{
	}

	public class AnimationSlot : MonoBehaviour
	{
	}

	public class KeySet : MonoBehaviour
	{
	}

	public class NoteOverride : MonoBehaviour
	{
	}

	public class IKNoteTarget : MonoBehaviour
	{
	}

	public class NoteBinding : MonoBehaviour
	{
		public float startedPlayingNote;
		public float minimumNoteTime;
		public float minimumSoundFadeOutTime;
		public bool lastNoteState;
		public bool blockUntilRelease;
		public float PitchOffset;
		public bool MidiOn;
		public bool MouseOn;
		public bool Playing;
		public float PlayingDuration;
		public bool RecentlyPlayedNote;
	}

}