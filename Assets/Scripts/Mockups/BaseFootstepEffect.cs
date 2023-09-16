using UnityEngine;

public class BaseFootstepEffect : MonoBehaviour
{
	public float lastFootstepTime;
	public UnityEngine.Vector3 lastFootstepPos;

	public class GroundInfo : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
	}

}