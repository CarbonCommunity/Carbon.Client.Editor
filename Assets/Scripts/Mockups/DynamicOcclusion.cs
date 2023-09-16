using UnityEngine;

public class DynamicOcclusion : MonoBehaviour
{
	public float minOccluderArea;
	public int waitFrameCount;
	public float minSurfaceRatio;
	public float maxSurfaceDot;
	public float planeOffset;
	public int m_FrameCountToWait;
	public float m_RangeMultiplier;
	public uint m_PrevNonSubHitDirectionId;

	public class Direction : MonoBehaviour
	{
	}

}