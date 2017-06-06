using UnityEngine;
using System.Collections;

public class InstantiateUICanvas : MonoBehaviour 
{
	public GameObject canvasPrefab;

	public void InstantiateCanvas()
	{
		Instantiate (canvasPrefab, Vector3.zero, Quaternion.identity);
	}
}
