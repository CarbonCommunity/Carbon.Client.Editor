using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Carbon
{
    public class HeadBob : MonoBehaviour
    {
		public FirstPersonController Player;
		public float Speed;

		public Animation LaunchAnim;
		public Animation LandAnim;

		public Transform Target;

		internal Animation _current;
		internal bool _isLanding;
		internal float _time;
		internal float _timeout;

		public void Start()
		{
			Player.OnLaunch = PlayLaunch;
			Player.OnLand = PlayLand;
		}
		public void Update()
		{
			if(_current == null)
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
			_current.Apply(Target, _time);
		}

		public void PlayLaunch()
		{
			_time = 0;
			_current = LaunchAnim;
		}
		public void PlayLand()
		{
			_time = 0;
			_current = LandAnim;
		}

		[Serializable]
		public class Animation
		{
			public AnimationCurve Position;
			public AnimationCurve Rotation;

			public float Time => Position.keys.Sum(x => x.time);
			public void Apply(Transform transform, float time)
			{
				transform.localPosition = new Vector3(0f, Position.Evaluate(time), 0f);
				transform.localRotation = Quaternion.Euler(new Vector3(Rotation.Evaluate(time), 0f, 0f));
			}
		}
	}
}
