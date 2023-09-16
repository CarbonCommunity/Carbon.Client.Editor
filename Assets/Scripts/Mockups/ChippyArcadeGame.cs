using UnityEngine;

public class ChippyArcadeGame : MonoBehaviour
{
	public UnityEngine.Vector2 mouseAim;
	public bool OnMainMenu;
	public bool GameActive;
	public int level;
	public int selectedButtonIndex;
	public bool OnHighScores;
	public float lastInputTime;
	public float nextFireTime;
	public float nextClickTime;
	public int frameRate;
	public bool clientside;
	public bool clientsideInput;
	public bool isAuthorative;
	public float lastFrameRate;
	public uint lastEntityID;
	public bool currentGameVisibility;
	public float lastSnapshotTime;

}