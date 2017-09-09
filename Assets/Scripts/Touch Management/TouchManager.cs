using UnityEngine;
using System.Collections;


//A subject for observers (such as buttons), managing touch events including TouchBegin, TouchMoved, TouchEnded

public class TouchManager : MonoBehaviour 
{

	public delegate void TouchAction(Touch touch);
	//public delegate void SecondTouchAction(Touch touch1, Touch touch2);

	public static event TouchAction OnFirstTouch;
	public static event TouchAction OnFirstTouchBegin;
	public static event TouchAction OnFirstTouchMoved;
	public static event TouchAction OnFirstTouchEnded;
	/*public static event SecondTouchAction OnSecondTouch;
	public static event SecondTouchAction OnSecondTouchBegin;
	public static event SecondTouchAction OnSecondTouchMoved;
	public static event SecondTouchAction OnSecondTouchEnded;*/

	void Update()
	{
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			switch (touch.phase) {
			case TouchPhase.Began:
				if (OnFirstTouch != null)
					OnFirstTouch (touch);
				if (OnFirstTouchBegin != null)
					OnFirstTouchBegin (touch);
				break;
			case TouchPhase.Moved:
				if (OnFirstTouch != null)
					OnFirstTouch (touch);
				if (OnFirstTouchMoved != null)
					OnFirstTouchMoved (touch);
				break;
			case TouchPhase.Ended:
				if (OnFirstTouchEnded != null)
					OnFirstTouchEnded (touch);
				break;
			}
			//handles second touch
			/*if (Input.touchCount > 1) {
				Touch secTouch = Input.GetTouch (1);
				switch (touch.phase) {
				case TouchPhase.Began:
					if (OnSecondTouch != null)
						OnSecondTouch (touch, secTouch);
					if (OnSecondTouchBegin != null)
						OnSecondTouchBegin (touch, secTouch);
					break;
				case TouchPhase.Moved:
					if (OnSecondTouch != null)
						OnSecondTouch (touch, secTouch);
					if (OnSecondTouchMoved != null)
						OnSecondTouchMoved (touch, secTouch);
					break;
				case TouchPhase.Ended:
					if (OnSecondTouchEnded != null)
						OnSecondTouchEnded (touch, secTouch);
					break;
				}
			}*/
		}
	}
}
