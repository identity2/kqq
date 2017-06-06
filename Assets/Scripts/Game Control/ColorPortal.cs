using UnityEngine;
using System.Collections;

public class ColorPortal : MonoBehaviour 
{
	public ColorPortal toPortal;
	public GameObject triggerAudio;

	private bool onCooldown = false;
	public bool OnCooldown {
		get {
			return onCooldown;
		}
		set {
			if (value) {
				onCooldown = true;

				//reset the bool automatically after Cooldown
				Invoke ("ResetCooldown", Cooldown);
			}
		}
	}

	private const float Cooldown = 0.75f;
	private const float EnterPortalTime = 0.2f;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!onCooldown && col.gameObject.tag == "Player") {
			Instantiate (triggerAudio, Vector2.zero, Quaternion.identity);
			toPortal.OnCooldown = true;
			StartCoroutine (PlayerEnterPortalCoroutine (col.gameObject));
		}
	}

	void ResetCooldown()
	{
		onCooldown = false;
	}

	IEnumerator PlayerEnterPortalCoroutine(GameObject player)
	{
		SpriteColorLerpCoroutine anim = new SpriteColorLerpCoroutine (player, new Color (255f, 255f, 255f, 1f), new Color (255f, 255f, 255f, 0f), EnterPortalTime);

		//fade out
		player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		player.GetComponent<Rigidbody2D> ().angularVelocity = 0f;
		player.GetComponent<Rigidbody2D> ().isKinematic = true;
		StartCoroutine (anim.AnimationCoroutine ());
		yield return new WaitForSeconds (EnterPortalTime);

		player.transform.position = new Vector3(toPortal.gameObject.transform.position.x, toPortal.gameObject.transform.position.y, player.transform.position.z);

		//fade in
		StartCoroutine(anim.AnimationCoroutine(back: true));
		yield return new WaitForSeconds (EnterPortalTime);
		player.GetComponent<Rigidbody2D> ().isKinematic = false;
	}

	void OnEnable()
	{
		GameMoniter.startChangedEvent += StartStateChanged;
	}

	void OnDisable()
	{
		GameMoniter.startChangedEvent -= StartStateChanged;
	}

	void StartStateChanged(bool started)
	{
		//prevent the bug that player cannot reset during portal transmission
		if (!started) {
			StopAllCoroutines ();
		}
	}
}
