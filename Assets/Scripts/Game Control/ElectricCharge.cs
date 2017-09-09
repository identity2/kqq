using UnityEngine;
using System.Collections;

public class ElectricCharge : MonoBehaviour 
{
	public enum ChargeType {positive, negative}
	public ChargeType chargeType;

	void Start()
	{
		GameMoniter.Instance.AddCharge(this);
	}

	void OnDestroy()
	{
		if (GameMoniter.Instance)
			GameMoniter.Instance.RemoveCharge(this);
	}
}
