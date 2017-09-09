using UnityEngine;
using System.Collections;

public class TimeObjectSpawner : MonoBehaviour , Pausable
{
	public Transform fromPos;
	public Transform toPos;

	public GameObject[] spawnPrefabs;

	public float minInterval;
	public float maxInterval;

	public float minDuration;
	public float maxDuration;

	public GameObject spawnAudio;

	private float timestamp;
	private float nextSpawnTime;

	private bool paused = false;

	void Initialize()
	{
		timestamp = Time.timeSinceLevelLoad;
		nextSpawnTime = Random.Range (minDuration, maxDuration);
	}

	void OnDisable()
	{
		GameMoniter.startChangedEvent -= StartStateChanged;
	}

	void Update()
	{
		if (paused)
			return;

		if (Time.timeSinceLevelLoad - timestamp > nextSpawnTime) {
			GameObject t = (Instantiate (spawnPrefabs [Random.Range (0, spawnPrefabs.Length)], fromPos.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f))) as GameObject);
			t.GetComponent<TranslateFromTo>().Initialize (fromPos.position, toPos.position, Random.Range (minDuration, maxDuration));

			Instantiate (spawnAudio, Vector2.zero, Quaternion.identity);

			Initialize ();
		}
	}

	void Start()
	{
		//register to TimeControl
		TimeControlObject.pausables.Add(this);

		//register to GameMoniter
		GameMoniter.startChangedEvent += StartStateChanged;

		Initialize ();
	}

	public void Pause()
	{
		paused = true;
	}

	public void Resume()
	{
		paused = false;
	}

	public void Reset()
	{
		Resume ();
	}

	void StartStateChanged(bool started)
	{
		if (!started) {
			Initialize ();
		}
	}
}
