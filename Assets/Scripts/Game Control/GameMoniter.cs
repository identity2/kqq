using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//singleton
public class GameMoniter : MonoBehaviour
{
	//events
	public delegate void StartChanged(bool started);
	public static event StartChanged startChangedEvent;

	//singleton getter
	private static GameMoniter instance;
	public static GameMoniter Instance
	{
		get {
			if (isQuitting)
				return null;
			
			if (instance == null)
			{
				instance = FindObjectOfType (typeof(GameMoniter)) as GameMoniter;
				if (instance == null)
				{
					GameObject go = new GameObject ("Game Moniter");
					instance = go.AddComponent<GameMoniter>();
				}
			}
			return instance;
		}
	}

	private static bool isQuitting = false;

	private static float ForceConstant = 7f;

	public LevelInformation leveInfo;

	[System.NonSerialized] public List<GameObject> buttons = new List<GameObject>();
	[System.NonSerialized] public GameObject restartButton;
	[System.NonSerialized] public GameObject player;
	[System.NonSerialized] public GameObject scoreText;
	private float score;
	public float Score{
		get{ return score; }
	}
	private float timeStamp;
	private Rigidbody2D playerRigidBody;		//for core game movement
	public List<ElectricCharge> charges = new List<ElectricCharge>();
	private bool started = false;
	public bool Started { 
		set { 
			//most resets of the objects are done through events
			if (startChangedEvent != null)
				startChangedEvent (value);

			//other resets
			if (value) {
				timeStamp = Time.timeSinceLevelLoad;
				restartButton.SetActive (true);

			} else {
				
				//disable restart button
				restartButton.SetActive (false);

				//reset score
				score = 0f;
				scoreText.GetComponent<Text> ().text = "";

				//enable buttons
				foreach (GameObject go in buttons)
					go.SetActive (true);

				//TimeControlObjects
				TimeControlObject.Reset();
			}

			//switch background music
			//GameObject.FindWithTag ("Background Music").GetComponent<BackgroundMusicPlayer> ().SwitchMusic ();

			started = value; 
		} 
		get {
			return started;
		}
	}

	private GameMoniter(){}

	//if an instance already exists, destroy it
	void Start()
	{
		if (Instance != this)
			Destroy (this);
	}

	void FixedUpdate()
	{
		if (started) 
		{
			UpdateScore ();

			playerRigidBody = player.GetComponent<Rigidbody2D> ();
			foreach (ElectricCharge charge in charges) 
			{
				Vector2 distance = charge.transform.position - player.transform.position;
				float forceMagnitude = ForceConstant / Mathf.Pow (distance.magnitude, 3);
				float forceDirection = charge.chargeType == ElectricCharge.ChargeType.positive ? 1f : -1f;
				Vector2 force = forceMagnitude * forceDirection * distance;
				playerRigidBody.AddForce(force);
			}
				
		}
	}

	void UpdateScore()
	{
		score = Time.timeSinceLevelLoad - timeStamp;
		if (score > 99f)
			score = 99f;
		scoreText.GetComponent<Text> ().text = string.Format ("{0:F2}", score);
	}

	public void AddCharge(ElectricCharge charge)
	{
		charges.Add(charge);
	}

	public void RemoveCharge(ElectricCharge charge)
	{
		charges.Remove(charge);
	}

	//avoid leaving gameobjects when quitting the app

	void OnDisable()
	{
		isQuitting = true;
		instance = null;
	}

	void OnEnable()
	{
		isQuitting = false;
	}

	/*void OnApplicationQuit()
	{
		isQuitting = true;
	}*/
}
