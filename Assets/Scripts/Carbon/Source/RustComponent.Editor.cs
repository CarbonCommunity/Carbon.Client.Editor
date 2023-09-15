using ProtoBuf;
using UnityEditor;
using UnityEngine;

namespace Carbon.Client
{
	public partial class RustComponent
	{
		[ProtoIgnore, Header("Debugger")]
		public int ColorSwitch;

		[Header("Tools")]
		public LayerMask MaskLookup;

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
			}

			Gizmos.matrix = matrix;
		}

#endif
	}
}
