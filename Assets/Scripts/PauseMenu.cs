using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public bool isPaused;
	public GameObject pausedMenuCanvas;

	// Use this for initialization
	void Start () {
		//isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			Debug.Log ("Escape");
			isPaused = !isPaused;
		}

		if (isPaused) {
			pausedMenuCanvas.SetActive (true);
		} else {
			pausedMenuCanvas.SetActive (false);
		}

	}

	public void Resume() {
		isPaused = false;
	}

	public void QuitGame() {
		
	}

	public void Restart() {
		Application.LoadLevel (1);
	}
}

