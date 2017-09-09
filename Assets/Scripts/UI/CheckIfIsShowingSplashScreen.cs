using UnityEngine;

public class CheckIfIsShowingSplashScreen : MonoBehaviour 
{
	public GameObject[] enableGameObjects;

	private bool called = false;

	void Update()
	{
		if (!called && !Application.isShowingSplashScreen)
		{
			foreach (GameObject go in enableGameObjects)
			{
				go.SetActive(true);
			}
		}
	}
}
