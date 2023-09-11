using System;
using Newtonsoft.Json;
using ProtoBuf;
using UnityEditor;
using UnityEngine;

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

		[ProtoIgnore, Header("Debugging")]
		public Color OutlineColor = Color.white;
		public Color FillingColor = Color.white;

		internal Collider _collider = null;
		internal int _timeSinceRetry = 0;


		[Serializable, ProtoContract]
		public class Member
		{
			[ProtoMember(1)]
			public string Name;

			[ProtoMember(2)]
			public string Value;
		}

#if UNITY_EDITOR
		public void OnDrawGizmos()
		{
			if (_collider == null)
			{
				if ((Time.realtimeSinceStartup - _timeSinceRetry) > 5f)
				{
					_collider = GetComponent<Collider>();
				}

				return;
			}

			var matrix = Gizmos.matrix;
			Gizmos.matrix = transform.localToWorldMatrix;

			Handles.Label(transform.position, $"{TargetType}\n({CarbonUtils.GetRecursiveName(transform)})");

			switch (_collider)
			{
				case SphereCollider sphere:
					Gizmos.color = OutlineColor;
					Gizmos.DrawWireSphere(sphere.center, sphere.radius);

					Gizmos.color = FillingColor;
					Gizmos.DrawSphere(sphere.center, sphere.radius);
					break;

				case BoxCollider box:
					Gizmos.color = OutlineColor;
					Gizmos.DrawWireCube(box.center, box.size);

					Gizmos.color = FillingColor;
					Gizmos.DrawCube(box.center, box.size);
					break;
			}

			Gizmos.matrix = matrix;
		}
#endif
	}
}
