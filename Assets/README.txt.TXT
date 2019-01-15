Changes in DOTween Plugin:

DOTweenAnimation.cs

==
public bool autoKill = true
=>
public bool autoKill = false;
==

==
public bool autoPlay = true
=>
public bool autoPlay = false;
==

DOTweenAnimationInspector.cs


==
EditorGUIUtils.InspectorLogo();
=>
//EditorGUIUtils.InspectorLogo();
==


==
bool hasManager = _src.GetComponent<DOTweenVisualManager>() != null;
if (!hasManager)
{
    if (GUILayout.Button(new GUIContent("Add Manager", "Adds a manager component which allows you to choose additional options for this gameObject")))
    {
        _src.gameObject.AddComponent<DOTweenVisualManager>();
    }
}
=>
Fully commented
==