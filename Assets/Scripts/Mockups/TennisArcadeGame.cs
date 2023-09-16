using UnityEngine;

public class TennisArcadeGame : MonoBehaviour
{
	public float maxScore;
	public int paddle1Score;
	public int paddle2Score;
	public float sensitivity;
	public bool OnMainMenu;
	public bool GameActive;
	public float paddleMoveSpeed;
	public float lastInputTime;
	public float lastHeight;
	public float lastAIHeight;
	public int frameRate;
	public bool clientside;
	public bool clientsideInput;
	public bool isAuthorative;
	public float lastFrameRate;
	public uint lastEntityID;
	public bool currentGameVisibility;
	public float lastSnapshotTime;

}