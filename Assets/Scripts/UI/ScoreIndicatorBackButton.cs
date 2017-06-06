using UnityEngine;

public class ScoreIndicatorBackButton : MonoBehaviour 
{
	public GameObject currCanvas;

	#if UNITY_ANDROID || UNITY_EDITOR
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag("Ads Canvas") == null)
		{
			ButtonClicked();
		}
	}
	#endif

	public void ButtonClicked()
	{
		Destroy(currCanvas);
	}
}
