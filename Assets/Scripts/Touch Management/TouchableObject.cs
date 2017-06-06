using UnityEngine;
using System.Collections;

public abstract class TouchableObject : MonoBehaviour 
{

	//automatically subscribe to TouchManager for touch events
	void OnEnable()
	{
		TouchManager.OnFirstTouch += OnFirstTouch;
		TouchManager.OnFirstTouchBegin += OnFirstTouchBegin;
		TouchManager.OnFirstTouchEnded += OnFirstTouchEnded;
		TouchManager.OnFirstTouchMoved += OnFirstTouchMoved;
		/*TouchManager.OnSecondTouch += OnSecondTouch;
		TouchManager.OnSecondTouchBegin += OnSecondTouchBegin;
		TouchManager.OnSecondTouchEnded += OnSecondTouchEnded;
		TouchManager.OnSecondTouchMoved += OnSecondTouchMoved;*/
	}

	//automatically unsubscribe to TouchManager
	void OnDisable()
	{
		TouchManager.OnFirstTouch -= OnFirstTouch;
		TouchManager.OnFirstTouchBegin -= OnFirstTouchBegin;
		TouchManager.OnFirstTouchEnded -= OnFirstTouchEnded;
		TouchManager.OnFirstTouchMoved -= OnFirstTouchMoved;
		/*TouchManager.OnSecondTouch -= OnSecondTouch;
		TouchManager.OnSecondTouchBegin -= OnSecondTouchBegin;
		TouchManager.OnSecondTouchEnded -= OnSecondTouchEnded;
		TouchManager.OnSecondTouchMoved -= OnSecondTouchMoved;*/
	}
		
	abstract protected void OnFirstTouch (Touch touch);

	abstract protected void OnFirstTouchBegin (Touch touch);

	abstract protected void OnFirstTouchEnded (Touch touch);

	abstract protected void OnFirstTouchMoved (Touch touch);
	/*
	abstract protected void OnSecondTouch(Touch touch1, Touch touch2);

	abstract protected void OnSecondTouchBegin(Touch touch1, Touch touch2);

	abstract protected void OnSecondTouchMoved(Touch touch1, Touch touch2);

	abstract protected void OnSecondTouchEnded(Touch touch1, Touch touch2);*/
}
