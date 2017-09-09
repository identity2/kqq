using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class EnlargingRing : MonoBehaviour 
{
	public float startRad;
	public float endRad;
	public float duration;

	public float width;
	public float degPreSegment;

	private LineRenderer lineRenderer { get { return GetComponent<LineRenderer>(); } }

	void Start()
	{
		lineRenderer.positionCount = (int)(360f / degPreSegment) + 1;

		//obsolete
		//lineRenderer.SetVertexCount((int)(360f / degPreSegment) + 1);

		lineRenderer.startWidth = lineRenderer.endWidth = width;

		//obsolete
		//lineRenderer.SetWidth (width, width);
		StartCoroutine (AnimationCoroutine ());
	}

	void DrawCircle(float rad)
	{
		float x, y;
		float currAngle = 0f;

		for (int i = 0; i < ((int)(360f / degPreSegment)) + 1; i++) {
			x = Mathf.Sin (Mathf.Deg2Rad * currAngle);
			y = Mathf.Cos (Mathf.Deg2Rad * currAngle);
			lineRenderer.SetPosition (i, new Vector3 (x, y, 0f) * rad);
			currAngle += degPreSegment;
		}
	}

	IEnumerator AnimationCoroutine()
	{
		float i = 0f;
		while (i <= 1f) {
			i += Time.deltaTime / duration;
			DrawCircle (Mathf.Lerp (startRad, endRad, i));
			yield return null;
		}

		Destroy (gameObject);
	}
}
