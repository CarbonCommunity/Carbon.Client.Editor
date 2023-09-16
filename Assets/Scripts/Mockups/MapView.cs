using UnityEngine;

public class MapView : MonoBehaviour
{
	public bool ShowGrid;
	public bool ShowPointOfInterestMarkers;
	public bool ShowDeathMarker;
	public bool ShowSleepingBags;
	public bool AllowSleepingBagDeletion;
	public bool ShowLocalPlayer;
	public bool ShowTeamMembers;
	public bool ShowBagsOnBottom;
	public bool ShowTrainLayer;
	public bool ShowMissions;
	public bool ShowUndergroundLayers;
	public bool MLRSMarkerMode;
	public bool isShowingUndergroundLayers;
	public bool IsOpen;

	public class SleepingBagCluster : MonoBehaviour
	{
		public UnityEngine.Vector3 centre;
	}

	public class MapMarkerCluster : MonoBehaviour
	{
		public UnityEngine.Vector3 centre;
	}

}