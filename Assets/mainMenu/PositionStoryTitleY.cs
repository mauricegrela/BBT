using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionStoryTitleY : MonoBehaviour {


    private RectTransform rectTrans;
    //Vector2 pivot;
    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        //pos = rectTransform.position;
        //rect.position = Camera.main.ScreenToWorldPoint(new Vector2(rect.position.x, Screen.height / 2));

        rectTrans.position = new Vector2(rectTrans.position.x, Screen.height/2);

        //rectTrans.pivot = new Vector2(rectTrans.rect.width / 2, rectTrans.rect.height/2); //center of the rect
        //Vector2 size = rectTrans.rect.size;
        //Vector2 deltaPivot = rectTrans.pivot - pivot;
        //Vector3 deltaPosition = new Vector3(deltaPivot.x * size.x, deltaPivot.y * size.y);
        //rectTrans.pivot = pivot;

        //rectTrans.localPosition -= deltaPosition;

        //rect.position = new Vector2(rect.position.x, rect.rect.height / 2);

        //rect.position= new Vector2(rect.position.x, rect.rect.height/2);
        //rect.position = new Vector2(rect.position.x, Screen.height/2- rect.rect.height / 2);// good for iphon x

        //rect.
    }
    //void Update () 
    //{
    //    pos.y = OtherRectTransform.position.y;
    //    rectTransform.position = pos;
    //}
}
