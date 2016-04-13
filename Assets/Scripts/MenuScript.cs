using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	public Canvas quitMenu;
	public Button startButton;
	public Button exitButton;
	public Canvas instructionCanvas;

	// Use this for initialization
	void Start () {
		if (instructionCanvas != null)
			instructionCanvas.enabled = false;	
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

	public void Instruction() {
		instructionCanvas.enabled = true;
	}

	public void CloseInstruction() {
		instructionCanvas.enabled = false;
	}
}
