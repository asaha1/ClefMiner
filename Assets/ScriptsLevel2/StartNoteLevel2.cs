using UnityEngine;
using System.Collections;

public class StartNoteLevel2 : MonoBehaviour {
	public string Text;
	public bool drawNote = false;
	GameObject[] notes;

	void OnTriggerEnter2D(Collider2D item){
		Text = "Hello";
		Debug.Log ("Level2 Note Trigger Enter!");
		if (item.gameObject.name == "Hazel") {
			drawNote = true;
		}
	}

	public void OnClick() {
		notes [0].SetActive (false);
		drawNote = false;
	}

	void OnGUI() {
		if (drawNote == true) {
			//Time.timeScale = 0;
			notes = GameObject.FindGameObjectsWithTag("note");
			if (notes.Length == 0)
				Debug.Log ("Level2 Not found notes");
			else
				notes [0].SetActive (true);
		}
	}

	void Update()
	{
	}

}