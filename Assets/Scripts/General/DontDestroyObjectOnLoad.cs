using UnityEngine;
using System.Collections;

public class DontDestroyObjectOnLoad : MonoBehaviour
{
	void Start()
	{
		DontDestroyOnLoad (gameObject);
	}
}
