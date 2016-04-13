using UnityEngine;
using System.Collections;

public class HintScript : MonoBehaviour {
	public Canvas hintCanvas;

	// Use this for initialization
	void Start () {
		hintCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		showHint ();
	}

	public void showHint() {
		GameObject.Find("Hazel").GetComponent<PauseMenu>().isHint = true;
		hintCanvas.enabled = true;
	}

	public void closeHint() {
		hintCanvas.enabled = false;
		GameObject.Find("Hazel").GetComponent<PauseMenu>().isHint = false;
		gameObject.SetActive (false);
	}
}
