using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Serialization;

namespace Carbon
{
	[ExecuteAlways]
    public class Environment : MonoBehaviour
	{
		public float Time;

		[FormerlySerializedAs("DayCurve")]
		public AnimationCurve DayLightCurve;
		public AnimationCurve DayAmbientCurve;
		public Material DaySkybox;

		[FormerlySerializedAs("NightCurve")]
		public AnimationCurve NightLightCurve;
		public AnimationCurve NightAmbientCurve;
		public Material NightSkybox;

	    public void Update()
	    {

	    }
    }

	#if UNITY_EDITOR

	[CustomEditor(typeof(Environment))]
	public class EnvironmentEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			var env = (Environment)target;

			env.Time = EditorGUILayout.Slider("Time", env.Time, 0f, 24f);

			GUILayout.Space(5);
			GUILayout.Label("Skyboxes", EditorStyles.boldLabel);
			env.DaySkybox = (Material)EditorGUILayout.ObjectField("Day Skybox", env.DaySkybox, typeof(Material), true);
			env.NightSkybox = (Material)EditorGUILayout.ObjectField("Night Skybox", env.NightSkybox, typeof(Material), false);

			GUILayout.Space(5);
			GUILayout.Label("Settings", EditorStyles.boldLabel);
			// env.DayLightCurve = (AnimationCurve)EditorGUILayout.ObjectField("Day Light Curve", env.DayLightCurve);
		}
	}

	#endif
}
