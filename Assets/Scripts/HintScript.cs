using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
