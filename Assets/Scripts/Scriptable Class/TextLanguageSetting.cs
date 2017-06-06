using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Language Setting/Text")]
public class TextLanguageSetting : SetLanguageBaseClass
{
	public string englishText;
	public string chineseText;

	public override void SetLanguage (GameObject go)
	{
		if (Application.systemLanguage == SystemLanguage.Chinese || 
			Application.systemLanguage == SystemLanguage.ChineseTraditional ||
			Application.systemLanguage == SystemLanguage.ChineseSimplified) {
			go.GetComponent<Text> ().text = chineseText;
		} else {
			go.GetComponent<Text> ().text = englishText;
		}
	}
}
