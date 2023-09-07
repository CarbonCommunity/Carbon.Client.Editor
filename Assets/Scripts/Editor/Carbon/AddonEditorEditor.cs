using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AddonEditor), true)]
public class AddonEditorEditor : Editor
{
	public List<string> ErrorList { get; } = new List<string>();

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

		// GUILayout.FlexibleSpace();
		// 
		// //
		// // Workshop Area
		// //
		// {
		// 	GUILayout.Label("Workshop", EditorStyles.boldLabel);
		// 
		// 	EditorGUILayout.HelpBox("When you press the button below changes will be made to your workshop items. Make sure everything is set up properly by clicking on Preview In Scene to see what we'll see when we load it up.", MessageType.Info);
		// 
		// 	foreach (var str in ErrorList)
		// 	{
		// 		EditorGUILayout.HelpBox(str, MessageType.Error);
		// 	}
		// 
		// 	EditorGUILayout.LabelField("Change Notes:");
		// 
		// 	EditorGUILayout.BeginHorizontal();
		// 
		// 	if (GUILayout.Button("VIEW ONLINE", GUILayout.ExpandWidth(false)))
		// 	{
		// 		Application.OpenURL("http://steamcommunity.com/sharedfiles/filedetails/?id=");
		// 	}
		// 
		// 	EditorGUILayout.EndHorizontal();
	}
}
