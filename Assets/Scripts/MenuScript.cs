using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	
	public Canvas quitMenu;
	public Button startButton;
	public Button exitButton;
	public Canvas instructionCanvas;
	public Canvas descriptionsCanvas;

	// Use this for initialization
	void Start () {
		if (instructionCanvas != null)
			instructionCanvas.enabled = false;	
		if (descriptionsCanvas != null)
			descriptionsCanvas.enabled = false;
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

	public void StartLevel(){
		SceneManager.LoadScene (1);
	}


	public void StartTutorial(){
		descriptionsCanvas.enabled = true;
	}
	public void CloseDescription(){
		descriptionsCanvas.enabled = false;
		StartLevel ();
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

	public void StartGameDirectly(){
		SceneManager.LoadScene (3);
	}
}
