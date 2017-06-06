using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LittlePos : MonoBehaviour
{
	public GameObject[] objectsToDestroy;
	public Text gameScoreText;

	[Header("Lil' Neg & Pos")]
	public GameObject littleNeg;

	public Vector3 littlePosToPos;
	public Vector3 littleNegToPos;

	public GameObject heart;
	public GameObject inLoveAudio;

	public GameObject negStone;
	public Vector3 negStoneToPos;

	[Header("Game Title")]
	public GameObject gameTitle;
	public Vector3 titleToPos;
	public Vector3 titleToLocalScale;

	[Header("Win Scene")]
	public GameObject winSceneCanvas;

	private RotationLerpCoroutine littleNegRotationAnimation;
	private TransformLerpCoroutine littleNegTransformAnimation;
	private TransformLerpCoroutine littlePosTransformAnimation;
	private TransformLerpCoroutine titleTransformAnimation;
	private ScalingLerpCoroutine titleScalingAnimation;
	private TransformLerpCoroutine negStoneTransformAnimation;

	private const float AnimationDuration = 2f;
	private const float TitleScaleAnimationDuration = 1f;
	private const float NegStoneRisingDuration = 2f;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			//save high score
			float previousScore = GameDataLoaderAndSaver.dataControl.GetHighScore(4, 12);
			if (previousScore < 0f || previousScore > GameMoniter.Instance.Score) {
				GameDataLoaderAndSaver.dataControl.SetHighScoreAndSave (4, 12, GameMoniter.Instance.Score);
			}

			//make the score text invisible
			gameScoreText.color = new Color (0f, 0f, 0f, 0f);

			//disable restart button
			GameMoniter.Instance.restartButton.SetActive (false);

			littleNeg.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			littleNeg.GetComponent<Rigidbody2D> ().isKinematic = true;
			littleNeg.GetComponent<Rigidbody2D> ().angularVelocity = 0f;

			//destroy game objects
			foreach (GameObject go in objectsToDestroy) {
				Destroy (go);
			}

			//destroy charges
			foreach (ElectricCharge electricCharge in GameMoniter.Instance.charges) {
				GameObject go = electricCharge.gameObject;
				if (go != gameObject && go != negStone) {
					Destroy (go);
				}
			}

			//init coroutines
			littleNegRotationAnimation = new RotationLerpCoroutine (
				littleNeg,
				littleNeg.transform.eulerAngles.z,
				Quaternion.identity.eulerAngles.z,
				AnimationDuration
			);

			littleNegTransformAnimation = new TransformLerpCoroutine (
				littleNeg,
				littleNeg.transform.position,
				littleNegToPos,
				AnimationDuration
			);

			littlePosTransformAnimation = new TransformLerpCoroutine (
				gameObject,
				transform.position,
				littlePosToPos,
				AnimationDuration,
				true
			);

			//start coroutines
			StartCoroutine(littleNegRotationAnimation.AnimationCoroutine());
			StartCoroutine (littlePosTransformAnimation.AnimationCoroutine ());
			StartCoroutine (littleNegTransformAnimation.AnimationCoroutine ());

			//end
			StartCoroutine(EndCycle());
		}
	}

	IEnumerator EndCycle()
	{
		yield return new WaitForSeconds (AnimationDuration);

		//show heart
		heart.SetActive (true);

		//spawn in love audio
		Instantiate(inLoveAudio, transform.position, Quaternion.identity);

		//make negstone a whole game object
		gameObject.transform.parent = negStone.transform;
		littleNeg.transform.parent = negStone.transform;

		//title animation & neg stone rising
		titleTransformAnimation = new TransformLerpCoroutine (
			gameTitle,
			gameTitle.transform.position,
			titleToPos,
			TitleScaleAnimationDuration
		);

		titleScalingAnimation = new ScalingLerpCoroutine (
			gameTitle,
			gameTitle.transform.localScale,
			titleToLocalScale,
			TitleScaleAnimationDuration
		);

		negStoneTransformAnimation = new TransformLerpCoroutine (
			negStone,
			negStone.transform.position,
			negStoneToPos,
			TitleScaleAnimationDuration
		);

		StartCoroutine (titleTransformAnimation.AnimationCoroutine ());
		StartCoroutine (titleScalingAnimation.AnimationCoroutine ());

		yield return new WaitForSeconds (TitleScaleAnimationDuration);

		StartCoroutine (negStoneTransformAnimation.AnimationCoroutine ());

		yield return new WaitForSeconds (NegStoneRisingDuration);

		//activate win scene canvas
		winSceneCanvas.SetActive(true);
	}
}
