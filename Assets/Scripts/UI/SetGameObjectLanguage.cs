using UnityEngine;
using System.Collections;

public class SetGameObjectLanguage : MonoBehaviour 
{
	public SetLanguageBaseClass setting;

	void Start()
	{
		setting.SetLanguage (this.gameObject);
	}
}
