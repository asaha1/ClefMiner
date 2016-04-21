using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public bool isPaused;
	public bool isQuitMenuActive;
	public GameObject pausedMenuCanvas;
	public GameObject quitMenuCanvas;
	public bool isHint;
	public bool isGameOver;

	// Use this for initialization
	void Start () {
		isPaused = false;
		isHint = false;
		isGameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !isQuitMenuActive) {
			Debug.Log ("Escape");
			isPaused = !isPaused;
		}
		if (isHint || isGameOver) {
			Time.timeScale = 0f;
		}
		else if (isPaused) {
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
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void YesPress() {
		Application.Quit ();
	}

	public void NoPress() {
		isQuitMenuActive = false;
		quitMenuCanvas.SetActive (false);
		//pausedMenuCanvas.SetActive (true);
	}

	public void StartNoteLevel(){
		SceneManager.LoadScene (4);
	}

	public void StartMainMenu(){
		SceneManager.LoadScene (0);
	}
}

