using UnityEngine;
using System.Collections;

public class PausableKeepOnRotate : KeepOnRotate, Pausable
{
	private bool paused = false;

	public void Pause()
	{
		paused = true;
	}

	public void Resume()
	{
		paused = false;
	}

	public void Reset()
	{
		Resume ();
	}

	protected override void FixedUpdate ()
	{
		if (!paused)
			base.FixedUpdate ();
	}

	void OnEnable()
	{
		TimeControlObject.pausables.Add (this);
	}

	void OnDisable()
	{
		TimeControlObject.pausables.Remove (this);
	}
}
