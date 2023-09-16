using UnityEngine;

public class BaseArcadeGame : MonoBehaviour
{
	public int frameRate;
	public bool clientside;
	public bool clientsideInput;
	public bool isAuthorative;
	public float lastFrameRate;
	public uint lastEntityID;
	public bool currentGameVisibility;
	public float lastSnapshotTime;

}