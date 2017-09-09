using UnityEngine;
using System.Collections;

public class RandomShapeAndApplyForceRandomly : MonoBehaviour 
{
	public float forceCap;
	public float applyIntervalCap;
	public float minScale;
	public float maxScale;
	public float minAlpha;
	public float maxAlpha;

	public bool waitForNextTwoFrames;

	void Awake()
	{
		if (waitForNextTwoFrames) {
			StartCoroutine (WaitCoroutine ());
		} else {
			StartFunc ();
		}
	}

	IEnumerator WaitCoroutine()
	{
		yield return new WaitForEndOfFrame ();
		yield return new WaitForEndOfFrame ();

		StartFunc ();
	}

	void StartFunc()
	{
		gameObject.transform.localScale = gameObject.transform.localScale * Random.Range(minScale, maxScale);
		gameObject.GetComponent<SpriteRenderer>().color = new Color (255f, 255f, 255f, Random.Range (minAlpha, maxAlpha));
		StartCoroutine (ApplyForce ());
	}

	IEnumerator ApplyForce()
	{
		while (true) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range (-forceCap, forceCap), Random.Range (-forceCap, forceCap)));
			yield return new WaitForSeconds (Random.value * applyIntervalCap);
		}

	}
}
