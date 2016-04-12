using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	public Canvas quitMenu;
	public Button startButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {
		//quitMenu = quitMenu.GetComponent<Canvas> ();
		//startButton = startButton.GetComponent<Button> ();
		//exitButton = exitButton.GetComponent<Button> ();
		Time.timeScale = 0f;
		if (quitMenu != null)
			quitMenu.enabled = false;
	}

	public void ExitPress() {
		quitMenu.enabled = true;
		startButton.enabled = false;
		exitButton.enabled = false;
	}

	public void NoPress() {
		quitMenu.enabled = false;
		startButton.enabled = true;
		exitButton.enabled = true;
	}

	public void startLevel(){
		Application.LoadLevel (1);
	}

	public void ExitGame() {
		Application.Quit ();
	}
}
