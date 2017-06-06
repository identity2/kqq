using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinScoreText : MonoBehaviour 
{
	void Start()
	{
		if (Application.systemLanguage == SystemLanguage.Chinese || 
			Application.systemLanguage == SystemLanguage.ChineseTraditional ||
			Application.systemLanguage == SystemLanguage.ChineseSimplified)
			GetComponent<Text> ().text = "花了: " + GameMoniter.Instance.scoreText.GetComponent<Text> ().text + " 秒";
		else
			GetComponent<Text> ().text = "Spent: " + GameMoniter.Instance.scoreText.GetComponent<Text>().text + " sec";
	}
}
