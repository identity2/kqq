using UnityEngine;
using System.Collections;

public class KeepOnRotate : MonoBehaviour 
{
	public float rotateSpeed;

	protected virtual void FixedUpdate()
	{
		transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime));
	}
}
