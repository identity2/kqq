using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]

public class TouchableCollider : TouchableObject
{
	private bool onTheObject = false;
	protected bool OnTheObject { get { return onTheObject; } }

	private Collider2D Col { get { return GetComponent<Collider2D> (); } }

	protected override void OnFirstTouch (Touch touch)
	{
		CheckIfOnTheObject (touch);
	}

	protected override void OnFirstTouchBegin(Touch touch)
	{
		CheckIfOnTheObject (touch);
	}

	protected override void OnFirstTouchMoved(Touch touch)
	{
		CheckIfOnTheObject (touch);
	}

	protected override void OnFirstTouchEnded(Touch touch)
	{
		CheckIfOnTheObject (touch);
	}
	/*
	protected override void OnSecondTouch(Touch touch1, Touch touch2)
	{
		CheckIfOnTheObject (touch1, touch2);
	}

	protected override void OnSecondTouchBegin(Touch touch1, Touch touch2) 
	{
		CheckIfOnTheObject(touch1, touch2);
	}

	protected override void OnSecondTouchMoved(Touch touch1, Touch touch2)
	{
		CheckIfOnTheObject (touch1, touch2);
	}

	protected override void OnSecondTouchEnded (Touch touch1, Touch touch2)
	{
		CheckIfOnTheObject (touch1, touch2);
	}
	*/

	private void CheckIfOnTheObject(Touch touch1/*, Touch? touch2 = null*/)
	{
		onTheObject = (Col == Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (touch1.position)));
		/*if (touch2.HasValue)
			onTheObject = onTheObject || (Col == Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (touch2.Value.position)));*/
	}
}
