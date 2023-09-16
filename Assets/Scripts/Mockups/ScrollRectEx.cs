using UnityEngine;

public class ScrollRectEx : MonoBehaviour
{
	public bool m_Horizontal;
	public bool m_Vertical;
	public float m_Elasticity;
	public bool m_Inertia;
	public float m_DecelerationRate;
	public float m_ScrollSensitivity;
	public float m_HorizontalScrollbarSpacing;
	public float m_VerticalScrollbarSpacing;
	public UnityEngine.Vector2 m_PointerStartLocalCursor;
	public UnityEngine.Vector2 m_ContentStartPosition;
	public UnityEngine.Bounds m_ContentBounds;
	public UnityEngine.Bounds m_ViewBounds;
	public UnityEngine.Vector2 m_Velocity;
	public bool m_Dragging;
	public UnityEngine.Vector2 m_PrevPosition;
	public UnityEngine.Bounds m_PrevContentBounds;
	public UnityEngine.Bounds m_PrevViewBounds;
	public bool m_HasRebuiltLayout;
	public bool m_HSliderExpand;
	public bool m_VSliderExpand;
	public float m_HSliderHeight;
	public float m_VSliderWidth;
	public bool horizontal;
	public bool vertical;
	public float elasticity;
	public bool inertia;
	public float decelerationRate;
	public float scrollSensitivity;
	public float horizontalScrollbarSpacing;
	public float verticalScrollbarSpacing;
	public UnityEngine.Vector2 velocity;
	public UnityEngine.Vector2 normalizedPosition;
	public float horizontalNormalizedPosition;
	public float verticalNormalizedPosition;
	public bool hScrollingNeeded;
	public bool vScrollingNeeded;

	public class MovementType : MonoBehaviour
	{
	}

	public class ScrollbarVisibility : MonoBehaviour
	{
	}

	public class ScrollRectEvent : MonoBehaviour
	{
		public bool m_CallsDirty;
	}

}