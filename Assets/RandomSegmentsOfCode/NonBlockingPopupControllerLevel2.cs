/*using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NonBlockingPopupControllerLevel2 : MonoBehaviour {
	Image instrImage;
	Text instrText;
	// Use this for initialization
	void Start () {
		instrImage = gameObject.transform.GetChild (0).GetComponent<Image> ();
		instrText = gameObject.transform.GetChild (0).GetComponent<Image> ().transform.GetChild (0).GetComponent<Text> ();
		instrImage.enabled = false;
		instrText.enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public void showPopup(float x, float y, string text, string spriteName, float timeInSecs, string type) {
		Debug.Log ("show non blocking popup");
		instrImage.sprite = Resources.Load<Sprite> (spriteName);
		//instrImage.transform.position = new Vector3 (x, y, transform.position.z);
		instrText.text = text;
		startPopup (timeInSecs);
	}

	public void startPopup(float time){
		instrImage.enabled = true;
		instrText.enabled = true;
		StartCoroutine(disablePopupAfterWait (time));
	}

	IEnumerator disablePopupAfterWait(float duration){
		yield return new WaitForSeconds(duration);
		instrImage.enabled = false;
		instrText.enabled = false;
	}
}*/