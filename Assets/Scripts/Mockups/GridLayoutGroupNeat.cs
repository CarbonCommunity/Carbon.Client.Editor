using UnityEngine;

public class GridLayoutGroupNeat : MonoBehaviour
{
	public UnityEngine.Vector2 m_CellSize;
	public UnityEngine.Vector2 m_Spacing;
	public int m_ConstraintCount;
	public UnityEngine.Vector2 cellSize;
	public UnityEngine.Vector2 spacing;
	public int constraintCount;
	public UnityEngine.Vector2 m_TotalMinSize;
	public UnityEngine.Vector2 m_TotalPreferredSize;
	public UnityEngine.Vector2 m_TotalFlexibleSize;
	public float minWidth;
	public float preferredWidth;
	public float flexibleWidth;
	public float minHeight;
	public float preferredHeight;
	public float flexibleHeight;
	public int layoutPriority;
	public bool isRootLayoutGroup;

}