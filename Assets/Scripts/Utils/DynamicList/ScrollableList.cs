using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollableList : DynamicList
{
	public float sensitivity = 8;
	[Range (0, 1)]
	public float inertia = 0.9f;
	private ScrollRect scrollRect;

	private float movement;

	protected override void Awake ()
	{
		base.Awake ();
		scrollRect = GetComponentInChildren<ScrollRect> ();
	}

	private void Update ()
	{
		movement *= inertia;
		PointerEventData pointer = new PointerEventData (EventSystem.current);
		pointer.scrollDelta = new Vector2 (0, movement);
		scrollRect.OnScroll (pointer);
	}

	public void OnScrollButton (int direction)
	{
		movement = sensitivity * direction;
	}
}
