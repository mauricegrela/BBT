using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionStoryTitleY : MonoBehaviour {

    public RectTransform OtherRectTransform;
    Transform rectTransform;
    Vector3 pos;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        pos = rectTransform.position;
    }
    void Update () 
    {
        pos.y = OtherRectTransform.position.y;
        rectTransform.position = pos;
    }
}
