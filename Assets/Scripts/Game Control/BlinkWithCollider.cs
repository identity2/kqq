using UnityEngine;
using System.Collections;

public class BlinkWithCollider : MonoBehaviour 
{
	public float AppearTimeMin;
	public float AppearTimeMax;
	public float DisappearTimeMin;
	public float DisappearTimeMax;

	private SpriteColorLerpCoroutine anim;

	private const float FadeAnimationTime = 0.25f;

	private Collider2D[] colliders { get { return GetComponents<Collider2D> (); } }

	void Start()
	{

		anim = new SpriteColorLerpCoroutine (
			gameObject,
			new Color (255f, 255f, 255f, 1f),
			new Color (255f, 255f, 255f, 0f),
			FadeAnimationTime
		);
		StartCoroutine (Cycle ());
	}

	IEnumerator Cycle()
	{
		while (true) {
			//appear
			foreach (Collider2D col in colliders) {
				col.enabled = true;
			}
			yield return new WaitForSeconds(Random.Range(AppearTimeMin, AppearTimeMax));

			//fade out
			StartCoroutine (anim.AnimationCoroutine ());
			yield return new WaitForSeconds (FadeAnimationTime);

			//disappear
			foreach (Collider2D  col in colliders) {
				col.enabled = false;
			}
			yield return new WaitForSeconds (Random.Range (DisappearTimeMin, DisappearTimeMax));

			//fade in
			StartCoroutine (anim.AnimationCoroutine (back: true));
			yield return new WaitForSeconds (FadeAnimationTime);
		}
	}
}
