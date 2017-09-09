using UnityEngine;
using System.Collections;

public class StartLevel : MonoBehaviour 
{
	public void StartTheLevel()
	{
		GameMoniter.Instance.Started = true;
	}
}
