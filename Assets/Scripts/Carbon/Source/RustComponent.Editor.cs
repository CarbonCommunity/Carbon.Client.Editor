﻿#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Carbon.Client
{
	public partial class RustComponent
	{
		[Header("Debugger")]
		public ColorSwitch ColorSwitch;

		[Header("Tools")]
		public LayerMask MaskLookup;

		public Vector3 Debug;

		internal Collider _collider = null;
		internal float _timeSinceRetry = 0;

#if UNITY_EDITOR
		public Camera _sceneCamera => SceneView.currentDrawingSceneView.camera;

		public void OnDrawGizmos()
		{
			if (_collider == null)
			{
				if ((Time.realtimeSinceStartup - _timeSinceRetry) > 5f)
				{
					_collider = GetComponent<Collider>();
					_timeSinceRetry = Time.realtimeSinceStartup;
				}

				return;
			}

			var matrix = Gizmos.matrix;
			Gizmos.matrix = transform.localToWorldMatrix;

			if (Vector3.Distance(_sceneCamera.transform.position, transform.position) <= Defines.Singleton.InfoDistance)
			{
				var print = $"\n{Component.Type}{(Component.CreateOn.Server ? " [server]" : string.Empty)}{(Component.CreateOn.Client ? " [client]" : string.Empty)}";
				Handles.Label(transform.position, $"{print}");

				switch (_collider)
				{
					case SphereCollider sphere:
						Gizmos.color = Defines.Singleton.GetSwitch(ColorSwitch).Outline;
						Gizmos.DrawWireSphere(sphere.center, sphere.radius);
						break;

					case BoxCollider box:
						Gizmos.color = Defines.Singleton.GetSwitch(ColorSwitch).Outline;
						Gizmos.DrawWireCube(box.center, box.size);
						break;

					case CapsuleCollider capsule:
						Gizmos.color = Defines.Singleton.GetSwitch(ColorSwitch).Outline;
						Gizmos.DrawWireCube(capsule.center, new Vector3(capsule.radius * 2, capsule.height, capsule.radius * 2));
						break;
				}
			}

			switch (_collider)
			{
				case SphereCollider sphere:
					Gizmos.color = Defines.Singleton.GetSwitch(ColorSwitch).Main;
					Gizmos.DrawSphere(sphere.center, sphere.radius);
					break;

				case BoxCollider box:
					Gizmos.color = Defines.Singleton.GetSwitch(ColorSwitch).Main;
					Gizmos.DrawCube(box.center, box.size);
					break;

				case CapsuleCollider capsule:
					Gizmos.color = Defines.Singleton.GetSwitch(ColorSwitch).Main;
					Gizmos.DrawCube(capsule.center, Debug = new Vector3(capsule.radius * 2, capsule.height, capsule.radius * 2));
					break;
			}

			Gizmos.matrix = matrix;
		}
#endif
	}

#if UNITY_EDITOR
	[CustomEditor(typeof(RustComponent), true)]
	public class RustComponentEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			var component = (RustComponent)target;

			//
			// Tools Area
			//
			{
				GUILayout.Space(5);

				EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));

				var def = component.MaskLookup;
				def.value = int.Parse(GUILayout.TextField(component.MaskLookup.value.ToString()));
				component.MaskLookup = def;

				EditorGUILayout.EndHorizontal();
			}
		}
	}
#endif
}
