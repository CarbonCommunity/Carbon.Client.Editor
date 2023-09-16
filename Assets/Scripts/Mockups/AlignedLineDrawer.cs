using UnityEngine;

public class AlignedLineDrawer : MonoBehaviour
{
	public float LineWidth;
	public float SurfaceOffset;
	public float SprayThickness;
	public float uvTilingFactor;
	public bool DrawEndCaps;
	public bool DrawSideMesh;
	public bool DrawBackMesh;
	public bool isQueued;
	public bool queuedFinal;

	public class LinePoint : MonoBehaviour
	{
	}

	public class LineDrawerQueue : MonoBehaviour
	{
		public long warnTime;
		public long totalProcessed;
		public int queueProcessedLast;
		public int hashsetMaxLength;
		public int queueLength;
	}

}