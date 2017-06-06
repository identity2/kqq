using UnityEngine;
using System.Collections;

public class TimeBomb : MonoBehaviour, Pausable 
{
	public int countDown;
	public GameObject explosionPrefab;
	public TextMesh textMesh;

	[Header("Audio")]
	public GameObject tickAudio;
	public GameObject explodeAudio;

	private int currTime;
	private bool isCountingDown = false;
	private Animator anim { get { return GetComponent<Animator> (); } }



	public void Pause()
	{
		isCountingDown = false;
		anim.enabled = false;
		CancelInvoke ();
	}

	public void Reset()
	{

	}

	public void Resume()
	{
		//avoid multiple invokes
		if (isCountingDown)
			return;

		isCountingDown = true;
		anim.enabled = true;
		InvokeRepeating ("CountDownOneSec", 1f, 1f);
	}

	public void StartCountDown()
	{
		isCountingDown = true;
		if (countDown == 0) {
			Explode ();
		} else {
			anim.SetBool ("Count Down", true);
			InvokeRepeating ("CountDownOneSec", 1f, 1f);
		}
	}

	void Start()
	{
		//register to GameMoniter
		GameMoniter.startChangedEvent += StartStateChanged;

		ResetCountDown ();
	}

	void OnEnable()
	{
		TimeControlObject.pausables.Add (this);
	}

	void OnDisable()
	{
		TimeControlObject.pausables.Remove (this);
	}

	void OnDestroy()
	{
		GameMoniter.startChangedEvent -= StartStateChanged;
	}

	void ResetCountDown()
	{
		currTime = countDown;
		textMesh.text = currTime.ToString ();
	}

	void CountDownOneSec()
	{
		currTime--;
		textMesh.text = currTime.ToString ();

		Instantiate (tickAudio, Vector2.zero, Quaternion.identity);

		if (currTime == 0) {
			Explode ();
		} 
	}

	void Explode()
	{
		Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		Instantiate (explodeAudio, Vector2.zero, Quaternion.identity);
		gameObject.SetActive (false);
		CancelInvoke ();
	}

	void StartStateChanged(bool started)
	{
		if (started) {
			StartCountDown ();
		} else {
			//reset
			isCountingDown = false;
			gameObject.SetActive(true);
			CancelInvoke();
			anim.SetBool("Count Down", false);
			ResetCountDown ();
		}
	}
}
