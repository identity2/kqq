using UnityEngine;
using System.Collections;

//time object spawns
public class TranslateFromTo : MonoBehaviour , Pausable
{
	public Vector2 fromPos;
	public Vector2 toPos;

	public float fromAlpha;
	public float toAlpha;

	public float duration;

	public SpriteRenderer sr;

	private bool initialized = false;
	private bool paused = false;
	private float timestamp;
	private float pausedTimeStamp;

	public void Initialize(Vector2 fromPos, Vector2 toPos, float duration)
	{
		//register to time control objects (for pause/resume control)
		TimeControlObject.pausables.Add (this);

		//register to GameMoniter so it would be cleaned up when restarting
		GameMoniter.startChangedEvent += StartStateChanged;

		this.fromPos = fromPos;
		this.toPos = toPos;
		this.duration = duration;
		timestamp = Time.timeSinceLevelLoad;

		initialized = true;
	}

	public void Pause()
	{
		paused = true;
		pausedTimeStamp = Time.timeSinceLevelLoad;
	}

	public void Resume()
	{
		paused = false;
		timestamp = Time.timeSinceLevelLoad - pausedTimeStamp + timestamp;
	}

	public void Reset()
	{
		Resume ();
	}

	void Update()
	{
		if (paused || !initialized)
			return;

		float lerp = (Time.timeSinceLevelLoad - timestamp) / duration;
		transform.position = Vector2.Lerp (fromPos, toPos, lerp);
		sr.color = Color.Lerp (new Color (255f, 255f, 255f, fromAlpha), new Color (255f, 255f, 255f, toAlpha), lerp);

		//destroy the object if reaches
		if (lerp >= 1f)
			Destroy (gameObject);
	}

	void StartStateChanged(bool started)
	{
		if (!started) {
			Destroy (gameObject);
		}
	}

	void OnDestroy()
	{
		TimeControlObject.pausables.Remove (this);
		GameMoniter.startChangedEvent -= StartStateChanged;
	}
}
