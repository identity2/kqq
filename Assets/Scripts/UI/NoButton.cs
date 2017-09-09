using UnityEngine;

public class NoButton : MonoBehaviour 
{
	public GameObject currentCanvas;
	public bool enableBackButton = false;

	#if UNITY_ANDROID || UNITY_EDITOR
	void Update()
	{
		if (enableBackButton && Input.GetKeyDown (KeyCode.Escape)) {
			removeCurrentCanvas ();
		}
	}
	#endif

	public void removeCurrentCanvas(){
		Destroy (currentCanvas);
	}
}
