using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AddonEditor), true)]
public class AddonEditorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		var addon = (AddonEditor)target;

		//
		// Tools Area
		//
		{
			GUILayout.Space(16);

			GUILayout.Label("Tools", EditorStyles.boldLabel);

			EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));

			if (GUILayout.Button("Export Addon"))
			{
				addon.Build();
			}

			if (GUILayout.Button("Open/Generate Scene"))
			{
				addon.PrepareScene();
			}

			EditorGUILayout.EndHorizontal();

		}
	}
}
