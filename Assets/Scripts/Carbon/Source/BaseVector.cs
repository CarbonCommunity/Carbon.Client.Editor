/*
 *
 * Copyright (c) 2022-2023 Carbon Community 
 * All rights reserved.
 *
 */

using ProtoBuf;
using UnityEngine;

namespace Carbon.Client.Packets
{
	[ProtoContract]
	public class BaseVector
	{
		[ProtoMember(1)]
		public float X { get; set; }

		[ProtoMember(2)]
		public float Y { get; set; }

		[ProtoMember(3)]
		public float Z { get; set; }

		public Vector3 ToVector3()
		{
			return new Vector3(X, Y, Z);
		}

		public Quaternion ToQuaternion()
		{
			return Quaternion.Euler(X, Y, Z);
		}

		public static BaseVector ToProtoVector(Vector3 vector)
		{
			return new BaseVector
			{
				X = vector.x,
				Y = vector.y,
				Z = vector.z
			};
		}

		public static BaseVector ToProtoVector(Quaternion quat)
		{
			Vector3 euler = quat.eulerAngles;
			return new BaseVector
			{
				X = euler.x,
				Y = euler.y,
				Z = euler.z
			};
		}
	}
}
