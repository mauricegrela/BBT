using UnityEditor;

[CustomEditor(typeof(ScrollRectNested))]
public class ScrollRectNestedEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }
}