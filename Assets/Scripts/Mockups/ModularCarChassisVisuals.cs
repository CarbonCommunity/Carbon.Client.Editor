using UnityEngine;

public class ModularCarChassisVisuals : MonoBehaviour
{
	public float prevSteer;
	public bool isStopped;

	public class Steering : MonoBehaviour
	{
	}

	public class LookAtTarget : MonoBehaviour
	{
		public UnityEngine.Vector3 angleAdjust;
	}

}