using UnityEngine;
using System.Collections;

public class SetWinScene : MonoBehaviour 
{
	public NextLevel nextLevelButton;

	public void SetNextLevelToLevelIndex(int index) 
	{
		nextLevelButton.toIndex = index;
	}
}
