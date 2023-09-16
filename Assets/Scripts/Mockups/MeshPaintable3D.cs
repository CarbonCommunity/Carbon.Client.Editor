using UnityEngine;

public class MeshPaintable3D : MonoBehaviour
{
	public int textureWidth;
	public int textureHeight;
	public float _uvFactor;
	public int _lastDrawTime;

	public class DrawTextureJob : MonoBehaviour
	{
		public int textureWidth;
		public float textureScaleX;
		public float textureScaleY;
		public int uvWidth;
		public int paintWidth;
		public int paintHeight;
		public int startX;
		public int startY;
		public int endX;
		public bool isPaintBrush;
	}

}