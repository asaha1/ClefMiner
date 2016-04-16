using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HintScript : MonoBehaviour {
	public Canvas hintCanvas;

	public bool reloadLevelNeeded;
	public bool reloadNextLevelNeeded;

	// Use this for initialization
	void Start () {
		hintCanvas.enabled = false;
		reloadLevelNeeded = false;
		reloadNextLevelNeeded = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.name == "Hazel") {
			showHint ();
		}
	}

	public void showHint() {
		GameObject.Find("Hazel").GetComponent<PauseMenu>().isHint = true;
		hintCanvas.enabled = true;
	}

	public void closeHint() {
		hintCanvas.enabled = false;
		GameObject.Find("Hazel").GetComponent<PauseMenu>().isHint = false;
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		//
		if (reloadLevelNeeded) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			reloadLevelNeeded = false;
		}
		if (reloadNextLevelNeeded) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			reloadNextLevelNeeded = false;
		}
		//gameObject.SetActive (false);
	}

	public void setHint(string text, string spriteName) {
		//gameObject.SetActive (true);
		//GameObject.Find("Hazel").GetComponent<PauseMenu>().isHint = true;
		Text instrText = hintCanvas.transform.GetChild (1).GetComponent<Text> ();
		instrText.text = text;
		Image instrImage = hintCanvas.transform.GetChild (2).GetComponent<Image> ();
		instrImage.sprite = Resources.Load<Sprite> (spriteName);
	}
}
