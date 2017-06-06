using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour 
{
	void Start()
	{
		GameMoniter.Instance.scoreText = this.gameObject;
	}
}
