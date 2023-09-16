using UnityEngine;

public class OcclusionCulling : MonoBehaviour
{
	public bool usePixelShaderFallback;
	public bool useAsyncReadAPI;
	public bool useNativePath;
	public int hiZLevelCount;
	public int hiZWidth;
	public int hiZHeight;
	public bool HiZReady;

	public class BufferSet : MonoBehaviour
	{
		public int width;
		public int height;
		public int capacity;
		public int count;
		public bool Ready;
	}

	public class OnVisibilityChanged : MonoBehaviour
	{
		public bool method_is_virtual;
	}

	public class DebugFilter : MonoBehaviour
	{
	}

	public class DebugMask : MonoBehaviour
	{
	}

	public class DebugSettings : MonoBehaviour
	{
		public bool log;
		public bool showAllVisible;
		public bool showMipChain;
		public bool showMain;
		public int showMainLod;
		public bool showFallback;
		public bool showStats;
		public bool showScreenBounds;
	}

	public class HashedPoolValue : MonoBehaviour
	{
		public ulong hashedPoolKey;
		public int hashedPoolIndex;
	}

	public class SmartListValue : MonoBehaviour
	{
		public int hashedListIndex;
	}

	public class SmartList : MonoBehaviour
	{
		public int count;
		public int Size;
		public int Count;
		public int Capacity;
	}

	public class Cell : MonoBehaviour
	{
		public int x;
		public int y;
		public int z;
		public UnityEngine.Bounds bounds;
		public bool isVisible;
		public ulong hashedPoolKey;
		public int hashedPoolIndex;
	}

	public class Sphere : MonoBehaviour
	{
	}

}