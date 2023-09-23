using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Carbon
{
	public class Noclip : MonoBehaviour
	{
		[Header("References")]
		public FirstPersonController Controller;
		public HeadBob Headbob;

		[Header("Properties")]
		public Vector3 BodyMove;
		public Vector3 CameraMove;
		public float Lerp;
		public float Speed;
		public float LookSensitivity;

		public Transform Transform => Controller.playerEyes;
		public bool IsNoclipping => !Headbob.enabled;

		public void DoNoclip(bool wants)
		{
			Controller.playerCanMove = !wants;
			Controller.enableJump = !wants;
			Controller.cameraCanMove = !wants;
			Headbob.enabled = !wants;

			if (!wants)
			{
				Controller.playerEyes.localPosition = Vector3.zero;
			}
			else
			{
				Headbob.Steps.Rigidbody.velocity = Headbob.Steps.Rigidbody.angularVelocity = Vector3.zero;
			}
		}

		public void Awake()
		{
			BodyMove = Transform.position;
		}
		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				DoNoclip(!IsNoclipping);
			}

			if (Input.GetKeyDown(KeyCode.Q))
			{
				Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
				Controller.cameraCanMove = Cursor.lockState == CursorLockMode.Locked;
			}

			if (IsNoclipping)
			{
				var mouseDelta = LookSensitivity * new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
				var rotation = Transform.rotation;
				var horiz = Quaternion.AngleAxis(mouseDelta.x, Vector3.up);
				var vert = Quaternion.AngleAxis(mouseDelta.y, Vector3.right);

				BodyMove += GetAccelerationVector() * Time.deltaTime;

				Transform.position += BodyMove * Time.deltaTime;
				Transform.rotation = horiz * rotation * vert;

				BodyMove = Vector3.Lerp(BodyMove, Vector3.zero, Lerp * Time.deltaTime);
			}
		}

		Vector3 GetAccelerationVector()
		{
			Vector3 moveInput = default;

			void AddMovement(KeyCode key, Vector3 dir)
			{
				if (Input.GetKey(key))
					moveInput += dir;
			}

			AddMovement(KeyCode.W, Vector3.forward);
			AddMovement(KeyCode.S, Vector3.back);
			AddMovement(KeyCode.D, Vector3.right);
			AddMovement(KeyCode.A, Vector3.left);
			AddMovement(KeyCode.Space, Vector3.up);
			AddMovement(KeyCode.LeftControl, Vector3.down);
			Vector3 direction = Transform.TransformVector(moveInput.normalized);

			if (Input.GetKey(KeyCode.LeftShift))
				return direction * (Speed * Lerp); // "sprinting"
			return direction * Speed; // "walking"
		}
	}
}
