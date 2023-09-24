using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Carbon
{
	public class Flashlight : MonoBehaviour
	{
		public GameObject LightObject;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				LightObject.SetActive(!LightObject.activeInHierarchy);
			}
		}
	}
}
