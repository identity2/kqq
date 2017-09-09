using UnityEngine;
using System.Collections;

public class GoToDestinations : MonoBehaviour 
{
	[Header("Set current location as the last position")]
	public Vector3[] Destinations;
	public float speed;	

	void Start()
	{
		GameMoniter.startChangedEvent += StartStateChanged;
	}

	void OnDisable()
	{
		GameMoniter.startChangedEvent -= StartStateChanged;
	}

	void StartStateChanged(bool started)
	{
		if (started) {
			StartCoroutine (GoThroughPath ());
		} else {
			StopAllCoroutines ();
			transform.position = Destinations [Destinations.Length - 1];
		}
	}

	IEnumerator GoThroughPath()
	{
		int currPos = Destinations.Length - 1;
		int nextPos = 0;
		float duration;
		TransformLerpCoroutine currMovement;

		while (true) {
			duration = Vector3.Distance (Destinations [currPos], Destinations [nextPos]) / speed;
			currMovement = new TransformLerpCoroutine (
				gameObject,
				Destinations[currPos],
				Destinations[nextPos],
				duration
			);
			StartCoroutine (currMovement.AnimationCoroutine ());
			yield return new WaitForSeconds (duration);

			nextPos = (nextPos + 1) % Destinations.Length;
			currPos = (currPos + 1) % Destinations.Length;
		}
	}
}
