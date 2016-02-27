using UnityEngine;
using System.Collections;

public class NoteController : MonoBehaviour {
	private AudioSource noteAudio;

	// Use this for initialization
	void Start () {
		noteAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D item){
		if (item.gameObject.name == "Hazel") {
			Player hz = item.gameObject.GetComponent<Player> (); 
			hz.incScore ();
			noteAudio.Play ();
			Destroy (gameObject);
		}
	}
}
