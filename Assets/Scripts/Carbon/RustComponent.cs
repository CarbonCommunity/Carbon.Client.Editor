using System;
using System.Linq;
using Newtonsoft.Json;
using ProtoBuf;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Carbon.Client
{
	[ProtoContract]
	public class RustComponent : MonoBehaviour
	{
		// public LayerMask LayerMaskTest = new LayerMask { value = 163840 };

		[ProtoMember(1)]
		public bool IsServer;

		[ProtoMember(2)]
		public bool IsClient;

		[ProtoMember(3)]
		public string TargetType;

		[ProtoMember(4)]
		public Member[] Members;

		[ProtoIgnore, Header("Debugger")]
		public int ColorSwitch;

		[Header("Tools")]
		public LayerMask MaskLookup;

		internal Collider _collider = null;
		internal float _timeSinceRetry = 0;


		[Serializable, ProtoContract]
		public class Member
		{
			[ProtoMember(1)]
			public string Name;

			[ProtoMember(2)]
			public string Value;
		}

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

			if (Vector3.Distance(_sceneCamera.transform.position, transform.position) <= 30)
			{
				var print = $"\n{TargetType}{(IsServer ? " [server]" : string.Empty)}{(IsClient ? " [client]" : string.Empty)}";
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
