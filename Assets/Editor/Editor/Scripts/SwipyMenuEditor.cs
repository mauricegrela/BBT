using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Editor 
/// </summary>
[CustomEditor(typeof(SwipyMenu))]
[CanEditMultipleObjects]
public class SwipyMenuEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		EditorGUILayout.HelpBox("Access this in script. To control it in Editor use SwipyMenuGenerator.", MessageType.Info);
	}
}