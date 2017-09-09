using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkSprite : MonoBehaviour 
{
	public float appearTimeMin;
	public float appearTimeMax;
	public float disappearTimeMin;
	public float disappearTimeMax;

	private SpriteRenderer sr { get { return GetComponent<SpriteRenderer> (); } }

	void Start()
	{
		StartCoroutine (Cycle ());
	}

	IEnumerator Cycle()
	{
		while (true) {
			sr.color = new Color (255f, 255f, 255f, 1f);

			yield return new WaitForSeconds (Random.Range (appearTimeMin, appearTimeMax));

			sr.color = new Color (255f, 255f, 255f, 0f);

			yield return new WaitForSeconds (Random.Range (disappearTimeMin, disappearTimeMax));
		}
	}
}
