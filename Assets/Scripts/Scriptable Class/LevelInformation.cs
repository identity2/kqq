using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "LevelInfo")]
public class LevelInformation : ScriptableObject
{
	public int galaxy;
	public int level;
	public int sceneIndex;
	public string chineseName;
	public string englishName;
}
