using UnityEngine;
using System.Collections;

public class MoveAlignXAxis : MonoBehaviour
{
	public float speed;

	void Update()
	{
		transform.Translate (Vector2.right * speed * Time.deltaTime);
	}
}
