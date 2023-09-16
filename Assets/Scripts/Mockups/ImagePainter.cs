using UnityEngine;

public class ImagePainter : MonoBehaviour
{
	public float spacingScale;

	public class OnDrawingEvent : MonoBehaviour
	{
		public bool m_CallsDirty;
	}

	public class PointerState : MonoBehaviour
	{
		public UnityEngine.Vector2 lastPos;
		public bool isDown;
	}

}