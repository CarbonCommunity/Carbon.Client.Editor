using UnityEngine;

public class CoverageQueries : MonoBehaviour
{
	public float depthBias;
	public bool debug;

	public class BufferSet : MonoBehaviour
	{
		public int width;
		public int height;
	}

	public class RadiusSpace : MonoBehaviour
	{
	}

	public class Query : MonoBehaviour
	{
		public bool IsRegistered;
	}

}