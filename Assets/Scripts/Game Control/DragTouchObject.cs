using UnityEngine;
using System.Collections;

public class DragTouchObject : TouchableCollider
{
	private static GameObject currentObject;

	//clamp within the boundaries
	private const float MinPosX = -2.5f;
	private const float MaxPosX = 2.5f;
	private const float MinPosY = -4f;
	private const float MaxPosY = 3.4f;

	//for the upper right trash can square
	private const float TossTurnPosX = 2f;
	private const float TossTurnPosY = 4.75f;

	protected override void OnFirstTouchBegin (Touch touch)
	{
		base.OnFirstTouchBegin (touch);

		//can't drag if the level has started
		if (GameMoniter.Instance.Started)
			return;
		
		if (base.OnTheObject)
			currentObject = this.gameObject;
	}

	protected override void OnFirstTouchMoved (Touch touch)
	{
		base.OnFirstTouchMoved(touch);

		if (currentObject != null) {
			float newX = Camera.main.ScreenToWorldPoint (touch.position).x;
			float newY = Camera.main.ScreenToWorldPoint (touch.position).y;

			//cannot overlap player
			if (GameMoniter.Instance.player.GetComponent<CircleCollider2D>().OverlapPoint(new Vector2(newX, newY))) 
				return;

			if (newX >= TossTurnPosX)
				newY = Mathf.Clamp (newY, MinPosY, TossTurnPosY);
			else
				newY = Mathf.Clamp (newY, MinPosY, MaxPosY);

			currentObject.transform.position = 
				new Vector3 (
				Mathf.Clamp (newX, MinPosX, MaxPosX),
				newY,
				transform.position.z
			);
		}
	}

	protected override void OnFirstTouchEnded(Touch touch)
	{
		base.OnFirstTouchEnded (touch);

		currentObject = null;
	}
}
