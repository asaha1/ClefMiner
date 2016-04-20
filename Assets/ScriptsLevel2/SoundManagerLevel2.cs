using UnityEngine;
using System.Collections;

// This Class is designed similar to unity tutorials.
public class SoundManagerLevel2 : MonoBehaviour 
{
	public AudioSource efxSource;
	public AudioSource musicSource;
	public AudioSource notePlaySource;
	public static SoundManagerLevel2 instance = null;


	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	public void PlaySingleWithVolume(AudioClip clip, float vol){
		notePlaySource.clip = clip;
		float exVolume = notePlaySource.volume;
		notePlaySource.volume = vol;
		notePlaySource.Play ();
		StartCoroutine (RestoreVolume (exVolume, 2f));
	}

	IEnumerator RestoreVolume(float exVol, float duration){
		yield return new WaitForSeconds (duration);
		notePlaySource.volume = exVol;
	}


	public void PlaySingle(AudioClip clip)
	{
		efxSource.clip = clip;
		efxSource.Play ();
	}
}