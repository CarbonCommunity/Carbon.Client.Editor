using Carbon.Client;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RustComponent), true)]
public class RustComponentEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		var component = (RustComponent)target;

		//
		// Tools Area
		//
		{
			GUILayout.Space(5);

			EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));

			var def = component.MaskLookup;
			def.value = int.Parse(GUILayout.TextField(component.MaskLookup.value.ToString()));
			component.MaskLookup = def;

			EditorGUILayout.EndHorizontal();
		}
	}
}
