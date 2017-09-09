using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreIndicator : MonoBehaviour
{
	private int galaxy;
	public int Galaxy { set { galaxy = value; } }

	private int level;
	public int Level { set { level = value; } }

	private int sceneIndex;
	public int SceneIndex { set { sceneIndex = value; } }

	private string levelName;
	public string LevelName { set { levelName = value; } }

	public Text levelText;
	public Text highScoreText;
	public Text levelNameText;

	public GameObject adsCanvasPrefab;

	public void UpdateText()
	{
		levelNameText.text = levelName;
		float highScore = GameDataLoaderAndSaver.dataControl.GetHighScore (galaxy, level);

		if (Application.systemLanguage == SystemLanguage.Chinese ||
			Application.systemLanguage == SystemLanguage.ChineseSimplified ||
			Application.systemLanguage == SystemLanguage.ChineseTraditional) {
			levelText.text = "第" + level + "關";
			highScoreText.text = "最高分: " + (highScore < 0f ? "無" : string.Format("{0:F2}", highScore)+" 秒");
		} else {
			levelText.text = "Level " + level;
			highScoreText.text = "Record: " + (highScore < 0f ? "None" : string.Format("{0:F2}", highScore)+" sec");
		}

		#if UNITY_ADS
		if (level % 3 == 0)
			Instantiate(adsCanvasPrefab, Vector2.zero, Quaternion.identity);
		#endif
	}

	public void StartButtonPressed()
	{
		SceneManager.LoadScene(sceneIndex);
	}
}
