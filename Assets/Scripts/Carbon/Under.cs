using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Carbon
{
	public class Under : MonoBehaviour
    {
		public float Distance = 10f;
		public float UnderAmbient = 0.5f;
		public float NormalAmbient = 1f;
		public PostProcessVolume Volume;
		public LayerMask Layer;

		internal bool _wasUnder;
		internal float _timer;

		public bool IsUnder => Physics.Raycast(transform.position, transform.up, Distance, Layer, QueryTriggerInteraction.Ignore);

		public void Update()
		{
			if ((Time.realtimeSinceStartup - _timer) <= 2f)
			{
				return;
			}

			if ((!_wasUnder && IsUnder) || (_wasUnder && !IsUnder))
			{
				Volume.weight = IsUnder ? 1f : 0f;
				StopAllCoroutines();
				StartCoroutine(FadeAmbient(IsUnder ? UnderAmbient : NormalAmbient, 1f));
			}

			_timer = Time.realtimeSinceStartup;
			_wasUnder = IsUnder;
		}

		internal IEnumerator FadeAmbient(float value, float time)
		{
			var current = 0f;
			var originalValue = RenderSettings.ambientIntensity;

			while (current <= time)
			{
				current += Time.deltaTime;
				RenderSettings.ambientIntensity = Mathf.Lerp(originalValue, value, current.Scale(0f, time, 0f, 1f));
				yield return null;
			}
		}
    }
}
