using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Carbon
{
    public class PlayerStep : MonoBehaviour
    {
		public bool IsClimbingSteps => (Time.realtimeSinceStartup - _timeSinceStepsClimbed) <= 0.4f;

		public LayerMask Mask;

		public float StepHeight = 0.3f;
		public Vector3 StepSmooth = new Vector3(0, 0.1f, 0f);
		public Vector3 GravityForce = new Vector3(0, -0.2f, 0f);

		public Transform RayUpper;
		public Transform RayLower;

		public Rigidbody Rigidbody;

		public Vector3 DirectionOne;
		public Vector3 DirectionTwo;

		internal int _rayTypes = 2;
		internal int _rayType;
		internal float _timeSinceStepsClimbed;

		public void DoStep()
		{
			Rigidbody.AddForce(GravityForce, ForceMode.Impulse);

			if (_rayType > _rayTypes)
			{
				_rayType = 0;
			}

			switch (_rayType)
			{
				case 0:
					Execute(Vector3.forward);
					break;

				case 1:
					Execute(DirectionOne);
					break;

				case 2:
					Execute(DirectionTwo);
					break;
			}

			_rayType++;

			void Execute(Vector3 direction)
			{
				if (Physics.Raycast(RayLower.transform.position, transform.TransformDirection(direction), 0.1f, Mask))
				{
					if (!Physics.Raycast(RayUpper.transform.position, transform.TransformDirection(direction), 0.2f, Mask))
					{
						Rigidbody.AddForce(StepSmooth, ForceMode.Impulse);
						_timeSinceStepsClimbed = Time.realtimeSinceStartup;
					}
				}
			}
		}
		public void Update()
		{
			DoStep();
		}
		public void FixedUpdate()
		{
			
		}
	}
}
