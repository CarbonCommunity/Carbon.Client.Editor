using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Carbon
{
    public class Options : MonoBehaviour
    {
		public ReflectionProbe Probe;

		[Header("Time of Day")]
		public Material DaySkybox;
		public Material NightSkybox;

		public void TimeOfDay(int index)
		{
			switch (index)
			{
				case 0:
					RenderSettings.skybox = DaySkybox;
					break;

				case 1:
					RenderSettings.skybox = NightSkybox;
					break;
			}

			Probe.RenderProbe();
		}
    }
}
