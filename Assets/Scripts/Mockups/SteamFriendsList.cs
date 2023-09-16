using UnityEngine;

public class SteamFriendsList : MonoBehaviour
{
	public bool IncludeFriendsList;
	public bool IncludeRecentlySeen;
	public bool IncludeLastAttacker;
	public bool IncludeRecentlyPlayedWith;
	public bool ShowTeamFirst;
	public bool HideSteamIdsInStreamerMode;
	public bool RefreshOnEnable;

	public class onFriendSelectedEvent : MonoBehaviour
	{
		public bool m_CallsDirty;
	}

}