using UnityEngine;

public class UINexusMap : MonoBehaviour
{
	public bool ShowLocalPlayer;
	public float OutOfBoundsScaleFactor;
	public float ZoneNameAlphaPower;
	public bool FollowingPlayer;
	public bool _isLoading;
	public long _mapMetadataLastUpdated;
	public bool _zoneDetailsVisible;

	public class MapMetadata : MonoBehaviour
	{
	}

	public class ZoneMetadata : MonoBehaviour
	{
	}

}