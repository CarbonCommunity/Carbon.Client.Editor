using UnityEngine;

public class CreationGibSpawner : MonoBehaviour
{
	public float startTime;
	public float duration;
	public float buildScaleAdditionalAmount;
	public bool started;
	public float effectSpacing;
	public bool invert;
	public UnityEngine.Vector3 buildDirection;
	public float startDelay;
	public float nextEffectTime;

	public class GibReplacement : MonoBehaviour
	{
	}

	public class EffectMaterialPair : MonoBehaviour
	{
	}

	public class ConditionalGibSource : MonoBehaviour
	{
		public UnityEngine.Vector3 pos;
	}

}