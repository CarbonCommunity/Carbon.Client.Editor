using UnityEngine;

public class EntityFlag_Animator : MonoBehaviour
{
	public float FloatOnState;
	public float FloatOffState;
	public int IntegerOnState;
	public int IntegerOffState;
	public int cachedHash;
	public bool cachedState;
	public int ParamHash;
	public bool runClientside;
	public bool runServerside;
	public bool hasRunOnce;
	public bool lastToggleOn;

	public class AnimatorMode : MonoBehaviour
	{
	}

}