using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Language Setting Image", menuName = "Language Setting/Image", order = 102)]
public class ImageLanguageSetting : SetLanguageBaseClass
{
	public Sprite englishSprite;
	public Sprite chineseSprite;

	public override void SetLanguage(GameObject go)
	{
		if (Application.systemLanguage == SystemLanguage.Chinese || 
			Application.systemLanguage == SystemLanguage.ChineseTraditional ||
			Application.systemLanguage == SystemLanguage.ChineseSimplified) {
			go.GetComponent<Image> ().sprite = chineseSprite;
		} else {
			go.GetComponent<Image> ().sprite = englishSprite;
		}
	}
}
