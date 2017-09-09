using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
	public int toScene;
	public GameObject confirmScene;

	//android back button
	#if UNITY_ANDROID || UNITY_EDITOR
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && GameObject.FindObjectOfType<SetWinScene>() == null)
		{
			ButtonClicked();
		}
	}
	#endif

	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			ButtonClicked ();
		}
		);
	}

	void ButtonClicked()
	{
		(Instantiate (confirmScene, Vector2.zero, Quaternion.identity) as GameObject).GetComponent<SetWinScene> ().SetNextLevelToLevelIndex (toScene);
	}
}
