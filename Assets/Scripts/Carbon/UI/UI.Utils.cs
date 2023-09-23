using System.Collections;
using UnityEngine;

namespace Carbon
{
	public static class UIUtils
	{
		public static void Fade(CanvasGroup canvas, float time, float alpha)
		{
			UI.Singleton.StartCoroutine(FadeImpl(canvas, time, alpha));
		}
		public static void Transition(Transform from, Vector3 toPos, Vector3 toRot, float time)
		{
			UI.Singleton.StartCoroutine(TransitionImpl(from, toPos, toRot, time));
		}

		private static IEnumerator FadeImpl(CanvasGroup canvas, float time, float alpha)
		{
			var currentTime = 0f;
			var initAlpha = canvas.alpha;

			while (currentTime <= time)
			{
				currentTime += Time.deltaTime;
				canvas.alpha = currentTime.Scale(initAlpha, alpha, 0f, 1f);
				yield return null;
			}
		}
		private static IEnumerator TransitionImpl(Transform from, Vector3 toPos, Vector3 toRot, float time)
		{
			var currentTime = 0f;
			var initPosition = from.position;
			var initRotation = from.rotation.eulerAngles;

			while (currentTime <= time)
			{
				currentTime += Time.deltaTime;

				var lerpValue = currentTime.Scale(0, time, 0f, 1f);
				from.SetPositionAndRotation(Vector3.Lerp(initPosition, toPos, lerpValue), Quaternion.Euler(Vector3.Lerp(initRotation, toRot, lerpValue)));
				yield return null;
			}
		}
	}
}
