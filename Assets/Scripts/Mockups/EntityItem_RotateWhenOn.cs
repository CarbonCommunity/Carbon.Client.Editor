using UnityEngine;

public class EntityItem_RotateWhenOn : MonoBehaviour
{
	public bool currentlyOn;
	public bool stateInitialized;

	public class State : MonoBehaviour
	{
		public UnityEngine.Vector3 rotation;
		public float initialDelay;
		public float timeToTake;
		public float movementLoopFadeOutTime;
	}

}