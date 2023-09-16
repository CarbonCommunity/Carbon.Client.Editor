using UnityEngine;

public class GenerateDungeonGrid : MonoBehaviour
{
	public int CellSize;
	public float LinkHeight;
	public float LinkRadius;
	public float LinkTransition;
	public bool RunOnCache;

	public class PathNode : MonoBehaviour
	{
	}

	public class PathSegment : MonoBehaviour
	{
	}

	public class PathLink : MonoBehaviour
	{
	}

	public class PathLinkSide : MonoBehaviour
	{
	}

	public class PathLinkSegment : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
		public UnityEngine.Vector3 scale;
	}

}