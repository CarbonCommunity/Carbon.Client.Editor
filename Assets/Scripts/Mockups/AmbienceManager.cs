using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
	public int maxActiveLocalEmitters;
	public int activeLocalEmitters;
	public float localEmitterRange;
	public bool isUnderwater;
	public float tickInterval;
	public float lastTick;

	public class EmitterTypeLimit : MonoBehaviour
	{
		public int limit;
		public int active;
	}

	public class AmbienceGroup : MonoBehaviour
	{
		public bool cullingGroupDirty;
	}

}