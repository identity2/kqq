using UnityEngine;
using System.Collections;

public class IncreaseAppliedForce : MonoBehaviour 
{
	public float increasePerSec;

	private float originalMinForce;
	private float originalMaxForce;

	private ApplyForceRandomly data { get { return GetComponent<ApplyForceRandomly>(); } }

	void Start()
	{
		originalMinForce = data.minForce;
		originalMaxForce = data.maxForce;

		GameMoniter.startChangedEvent += StartStateChanged;
	}

	void OnDisable()
	{
		GameMoniter.startChangedEvent -= StartStateChanged;
	}

	void StartStateChanged(bool started)
	{
		if (started) {
			InvokeRepeating ("IncreaseForce", 1f, 1f);
		} else {
			CancelInvoke ();
			data.minForce = originalMinForce;
			data.maxForce = originalMaxForce;
		}
	}

	void IncreaseForce()
	{
		data.minForce += increasePerSec;
		data.maxForce += increasePerSec;
	}
}
