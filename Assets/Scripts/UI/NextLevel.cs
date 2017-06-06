using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
	public int toIndex;

	public void ButtonClicked()
	{
		SceneTransitionAnim.instance.FadeOutAndGotoScene(toIndex);
	}
}
