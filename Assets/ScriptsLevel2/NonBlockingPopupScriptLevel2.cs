using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NonBlockingPopupScriptLevel2 : MonoBehaviour {
	Image instrImage;
	Image bgImage;
	Text instrText;
	// Use this for initialization
	void Start () {
		bgImage = gameObject.transform.GetChild (0).GetComponent<Image> ();
		instrImage = gameObject.transform.GetChild (1).GetComponent<Image> ();
		instrText = gameObject.transform.GetChild (1).GetComponent<Image> ().transform.GetChild (0).GetComponent<Text> ();
		instrImage.enabled = false;
		bgImage.enabled = false;
		instrText.enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public void showPopup(Vector3 position, string text, string spriteName, float timeInSecs, string type) {
		Debug.Log ("show non blocking popup");
		//instrImage.sprite = Resources.Load<Sprite> (spriteName);
		/*if (type == "POSITION_RESET") {
			Debug.Log ("ShoPopup :: type = " + type);
			instrImage.transform.position = position;
		}*/
		instrText.text = text;
		startPopup (timeInSecs, type);
	}

	public void startPopup(float time, string type){
		instrImage.enabled = true;
		if(type == "SHOW_BG")
			bgImage.enabled = true;
		instrText.enabled = true;
		StartCoroutine(disablePopupAfterWait (time));
	}

	IEnumerator disablePopupAfterWait(float duration){
		yield return new WaitForSeconds(duration);
		instrImage.enabled = false;
		bgImage.enabled = false;
		instrText.enabled = false;
	}
}