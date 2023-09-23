using System;
using System.Linq;
using UnityEngine;

namespace Carbon
{
	public class HeadBob : MonoBehaviour
	{
		public FirstPersonController Player;
		public PlayerStep Steps;
		public float Speed;

		public Animation LaunchAnim;
		public Animation LandAnim;

		public Transform Target;

		internal Animation _current;
		internal bool _isLanding;
		internal float _time;
		internal float _timeout;
		internal float _velocity;

		public void Start()
		{
			Player.OnLaunch = PlayLaunch;
			Player.OnLand = PlayLand;
		}
		public void Update()
		{
			if (_current == null)
			{
				return;
			}

			var time = _current.Time * Speed;

			if (_time > time)
			{
				_current = null;
				return;
			}

			_time += Time.deltaTime * Speed;
			_current.Apply(Target, _time, _velocity.Scale(1f, 5f, 1f, 0f).Clamp(0.9f, 1.5f));
		}

		public void PlayLaunch()
		{
			if (Steps.IsClimbingSteps)
			{
				return;
			}

			_velocity = Steps.Rigidbody.velocity.magnitude;
			_time = 0;
			_current = LaunchAnim;
		}
		public void PlayLand()
		{
			if (Steps.IsClimbingSteps)
			{
				return;
			}

			_velocity = Steps.Rigidbody.velocity.magnitude;
			_time = 0;
			_current = LandAnim;
		}

		[Serializable]
		public class Animation
		{
			public AnimationCurve Position;
			public AnimationCurve Rotation;

			public float Time => Position.keys.Sum(x => x.time);
			public void Apply(Transform transform, float time, float multiply = 1f)
			{
				transform.localPosition = new Vector3(0f, Position.Evaluate(time) * multiply, 0f);
				transform.localRotation = Quaternion.Euler(new Vector3(Rotation.Evaluate(time) * multiply, 0f, 0f));
			}
		}
	}
}
