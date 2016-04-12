using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public bool isPaused;
	public bool isQuitMenuActive;
	public GameObject pausedMenuCanvas;
	public GameObject quitMenuCanvas;

	// Use this for initialization
	void Start () {
		//isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !isQuitMenuActive) {
			Debug.Log ("Escape");
			isPaused = !isPaused;
		}

		if (isPaused) {
			Time.timeScale = 0f;
			pausedMenuCanvas.SetActive (true);
		} else {
			Time.timeScale = 1f;
			pausedMenuCanvas.SetActive (false);
		}

	}

	public void Resume() {
		isPaused = false;
	}

	public void QuitGame() {
		isQuitMenuActive = true;
		pausedMenuCanvas.SetActive (false);
		quitMenuCanvas.SetActive (true);
	}

	public void Restart() {
		Application.LoadLevel (1);
	}

	public void YesPress() {
		Application.Quit ();
	}

	public void NoPress() {
		isQuitMenuActive = false;
		quitMenuCanvas.SetActive (false);
		pausedMenuCanvas.SetActive (true);
	}
}

