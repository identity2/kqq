using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeControlObject : MonoBehaviour 
{
	public bool play;

	public GameObject triggerAudio;
	public GameObject triggerAnimation;

	public static List<Pausable> pausables = new List<Pausable>();

	private bool inCooldown = false;

	private const float Cooldown = 0.5f;

	public static void Reset()
	{
		foreach (Pausable p in pausables)
			p.Reset ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!inCooldown && col.gameObject.tag == "Player") {
			inCooldown = true;
			Invoke ("ResetCooldown", Cooldown);

			Instantiate (triggerAudio, Vector2.zero, Quaternion.identity);
			Instantiate (triggerAnimation, transform.position, Quaternion.identity);
			if (play) {
				foreach (Pausable p in pausables)
					p.Resume ();
			} else {
				foreach (Pausable p in pausables)
					p.Pause ();
			}
		}
	}
		
	void ResetCooldown()
	{
		inCooldown = false;
	}
}
