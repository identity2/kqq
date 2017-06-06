using UnityEngine;
using System.Collections;

public class TrashCan : MonoBehaviour 
{
	public GameObject posChargeControl;
	public GameObject negChargeControl;
	public GameObject blockControl;

	//audio
	public GameObject tossAudio;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Positive Charge") {
			Instantiate (tossAudio, Vector2.zero, Quaternion.identity);
			Destroy (col.gameObject);
			posChargeControl.GetComponent<InstantiateObject> ().AddUnitLimit ();
		} else if (col.gameObject.tag == "Negative Charge") {
			Instantiate (tossAudio, Vector2.zero, Quaternion.identity);
			Destroy (col.gameObject);
			negChargeControl.GetComponent<InstantiateObject> ().AddUnitLimit ();
		} else if (col.gameObject.tag == "Block") {
			Instantiate (tossAudio, Vector2.zero, Quaternion.identity);
			Destroy (col.gameObject);
			blockControl.GetComponent<InstantiateObject> ().AddUnitLimit ();
		}
	}
}
