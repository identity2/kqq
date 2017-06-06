using UnityEngine;
using System.Collections;

public class BackgroundMusicPlayer : MonoBehaviour 
{
	public AudioClip generalMusic;
	public float generalVolume;

	public AudioClip colorMusic;
	public float colorVolume;

	public AudioSource source { get { return GetComponent<AudioSource> (); } }

	void OnEnable()
	{
		//prevent having 2 bgmusic player
		GameObject otherPlayer = (GameObject.FindGameObjectWithTag("Background Music") as GameObject);

		if (otherPlayer != gameObject)
			Destroy (otherPlayer);

		if (source.clip != generalMusic) {
			source.clip = generalMusic;
			source.volume = generalVolume;
		}
	}

	public void CheckBackgroundMusic(bool isColor) {
		if (isColor && source.clip != colorMusic) {
			source.Stop ();
			source.clip = colorMusic;
			source.volume = colorVolume;
			source.Play ();
		} else if (!isColor && source.clip != generalMusic) {
			source.Stop ();
			source.clip = generalMusic;
			source.volume = generalVolume;
			source.Play ();
		}
	}
}
