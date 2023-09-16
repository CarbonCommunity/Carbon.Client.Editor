using UnityEngine;

public class MonumentNavMesh : MonoBehaviour
{
	public int NavMeshAgentTypeIndex;
	public int CellCount;
	public int CellSize;
	public int Height;
	public float NavmeshResolutionModifier;
	public bool overrideAutoBounds;
	public UnityEngine.Bounds Bounds;
	public bool forceCollectTerrain;
	public bool shouldNotifyAIZones;

}