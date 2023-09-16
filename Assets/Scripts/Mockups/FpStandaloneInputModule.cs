using UnityEngine;

public class FpStandaloneInputModule : MonoBehaviour
{
	public float m_PrevActionTime;
	public UnityEngine.Vector2 m_LastMoveVector;
	public int m_ConsecutiveMoveCount;
	public UnityEngine.Vector2 m_LastMousePosition;
	public UnityEngine.Vector2 m_MousePosition;
	public float m_InputActionsPerSecond;
	public float m_RepeatDelay;
	public bool m_ForceModuleActive;
	public bool allowActivationOnMobileDevice;
	public bool forceModuleActive;
	public float inputActionsPerSecond;
	public float repeatDelay;

}