using UnityEngine;
using System.Collections;

public class SpawnNumbersAndGoToMiddle : MonoBehaviour 
{
	public GameObject prefab;

	public float spawnMinInterval;
	public float spawnMaxInterval;

	public float moveTime;

	public Vector3 driftToPos;

	private GameObject number;
	private SpriteColorLerpCoroutine colorAnimation;
	private TransformLerpCoroutine transformAnimation;

	void Start()
	{
		number = (Instantiate (prefab, transform.position, Quaternion.identity) as GameObject);
		number.transform.parent = transform.parent;
		number.SetActive (false);
		colorAnimation = new SpriteColorLerpCoroutine (
			number,
			new Color (255f, 255f, 255f, 1f),
			new Color (255f, 255f, 255f, 0f),
			moveTime
		);

		transformAnimation = new TransformLerpCoroutine (
			number,
			transform.localPosition,
			driftToPos,
			moveTime,
			local: true
		);
			

		StartCoroutine (Cycle ());
	}

	IEnumerator Cycle()
	{
		while (true) {
			yield return new WaitForSeconds (Random.Range (spawnMinInterval, spawnMaxInterval));

			number.SetActive (true);
			number.transform.localRotation = Quaternion.Euler (0f, 0f, Random.Range (0f, 359f));
			StartCoroutine (transformAnimation.AnimationCoroutine ());
			StartCoroutine (colorAnimation.AnimationCoroutine ());
			yield return new WaitForSeconds (moveTime);

			number.SetActive (false);
		}
	}
}
