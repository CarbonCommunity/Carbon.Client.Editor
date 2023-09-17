using System.Collections;
using System.Collections.Generic;
using Carbon.Client;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

namespace Carbon
{
    public class MeasuringTape : MonoBehaviour
	{
		[Range(0.01f, 1.5f)]
		public float Increments = 0.25f;

		[Header("Settings")]
		public float AngleScale = 0.25f;
		public Color TextColor = Color.white;
		public Color LineColor = Color.white;

		[Header("References")]
		public GameObject Point;


#if UNITY_EDITOR
		public Camera _sceneCamera => SceneView.currentDrawingSceneView.camera;

		public void OnDrawGizmos()
		{
			if (Point == null && Increments != 0)
			{
				return;
			}

			var distance = Vector3.Distance(transform.position, Point.transform.position);
			Gizmos.color = LineColor;
			using (CarbonUtils.GUIColorChange.New(TextColor, false))
			{
				Handles.Label(transform.position, $"  {0:0.0}m", EditorStyles.boldLabel);

				for (float i = 0; i < distance / Increments; i += Increments)
				{
					var direction = Point.transform.position - transform.position;
					var newPosition = transform.position + (direction * i);

					if (newPosition.y > Point.transform.position.y)
					{
						break;
					}

					var newDistance = Vector3.Distance(transform.position, newPosition);
					if (i != 0) Handles.Label(newPosition, $"  {newDistance:0.0}m");
				}

				// Handles.Label(Point.transform.position, $"  {distance:0.0}m", EditorStyles.boldLabel);
				Gizmos.DrawLine(transform.position, Point.transform.position);
			}

			Gizmos.DrawLine(transform.position, transform.position + (transform.right * AngleScale));
			Gizmos.DrawLine(Point.transform.position, Point.transform.position + (Point.transform.right * AngleScale));
		}
#endif
	}
}
