using UnityEngine;

public class PieMenu : MonoBehaviour
{
	public float sliceGaps;
	public float outerSize;
	public float innerSize;
	public float iconSize;
	public float startRadius;
	public float radiusSize;
	public bool isClosing;

	public class MenuOption : MonoBehaviour
	{
		public bool disabled;
		public int order;
		public bool showOverlay;
		public float time;
		public bool selected;
		public bool allowMerge;
		public bool wantsMerge;
	}

}