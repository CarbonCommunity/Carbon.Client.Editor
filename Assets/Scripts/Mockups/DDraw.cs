using UnityEngine;

public class DDraw : MonoBehaviour
{

	public class BaseObject : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
		public float end;
		public float start;
		public float delta;
		public bool distanceFade;
		public bool ztest;
	}

	public class CapsuleObj : MonoBehaviour
	{
		public float radius;
		public float height;
		public UnityEngine.Vector3 position;
		public float end;
		public float start;
		public float delta;
		public bool distanceFade;
		public bool ztest;
	}

	public class SphereObj : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
		public float end;
		public float start;
		public float delta;
		public bool distanceFade;
		public bool ztest;
	}

	public class SphereGizmoObj : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
		public float end;
		public float start;
		public float delta;
		public bool distanceFade;
		public bool ztest;
	}

	public class LineObj : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
		public float end;
		public float start;
		public float delta;
		public bool distanceFade;
		public bool ztest;
	}

	public class CubeObj : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
		public float end;
		public float start;
		public float delta;
		public bool distanceFade;
		public bool ztest;
	}

	public class ArrowHead : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
		public float end;
		public float start;
		public float delta;
		public bool distanceFade;
		public bool ztest;
	}

	public class TextObj : MonoBehaviour
	{
		public float scaleMulti;
		public bool draw;
		public UnityEngine.Vector3 position;
		public float end;
		public float start;
		public float delta;
		public bool distanceFade;
		public bool ztest;
	}

	public class ScreenTextObj : MonoBehaviour
	{
		public int x;
		public int y;
		public UnityEngine.Vector3 position;
		public float end;
		public float start;
		public float delta;
		public bool distanceFade;
		public bool ztest;
	}

}