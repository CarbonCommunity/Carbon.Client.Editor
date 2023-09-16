using UnityEngine;

public class MeshPaintController : MonoBehaviour
{
	public UnityEngine.Vector2 brushScale;
	public float brushSpacing;
	public float brushPreviewScaleMultiplier;
	public bool applyDefaults;
	public float defaultBrushSize;
	public float defaultBrushAlpha;
	public float maxBrushScale;
	public UnityEngine.Vector3 lastPosition;
	public bool drawingBlocked;

}