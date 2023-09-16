using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public float intensity;
	public int holdIntensityUntilBar;
	public bool musicPlaying;
	public bool loadingFirstClips;
	public float clipUpdateInterval;
	public int lastActiveClipRefresh;
	public int activeClipRefreshInterval;
	public bool forceThemeChange;
	public float randomIntensityJumpChance;
	public int clipScheduleBarsEarly;
	public int currentBar;
	public int barOffset;
	public bool needsResync;
	public int fadingClipCount;
	public int themeBar;

	public class ClipPlaybackData : MonoBehaviour
	{
		public bool isActive;
		public bool fadingIn;
		public bool fadingOut;
		public bool needsSync;
	}

}