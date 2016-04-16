using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HintScript : MonoBehaviour {
	public Canvas hintCanvas;
	public Canvas reviewCanvas;
	public bool reloadLevelNeeded;
	public bool reloadNextLevelNeeded;
	public bool reloadMain;

	// Use this for initialization
	void Start () {
		hintCanvas.enabled = false;
		if(reviewCanvas)
			reviewCanvas.enabled = false;
		reloadLevelNeeded = false;
		reloadNextLevelNeeded = false;
		reloadMain = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.name == "Hazel") {
			showHint ();
		}
	}


	public void ShowReview(){
		reviewCanvas.enabled = true;
	}

	public void HideReview(){
		reviewCanvas.enabled = false;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
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
		if (reloadMain) {
			string[] enemySprites = new string[6];
			string[] enemyNames = new string[6];
			string[] enemies = FriendEnemyManager.instance.GetEnemyNames();
			enemySprites [0] = enemies [0];
			enemySprites [1] = enemies [1];
			enemySprites [2] = enemies [0];
			enemySprites [3] = enemies [1];
			enemySprites [4] = enemies [0];
			enemySprites [5] = enemies [1];

			enemyNames [0] = "F Clef\nEnemy!";
			enemyNames [1] = "G Clef\nEnemy!";
			enemyNames [2] = "F Clef\nEnemy!";
			enemyNames [3] = "G Clef\nEnemy!";
			enemyNames [4] = "F Clef\nEnemy!";
			enemyNames [5] = "G Clef\nEnemy!";
			SetUpReview ("Following are the Clefs that you are going to find in the main arena. \nFind as much of them " +
				"as you can.\nPress OKAY to start!", "NotationsSprites/Clefs/C_Clef", "C Clef\nYour Friend!", enemySprites, enemyNames, "NONE");
			GameObject.Find("Hazel").GetComponent<PauseMenu>().isHint = true;
			ShowReview ();
			reloadMain = false;
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

	public void SetUpReview(string message, string friendSprite,string friendName, string[] enemySprites, string[] enemyNames, string kind){
		Text reviewText = reviewCanvas.transform.GetChild (1).GetComponent<Text> ();
		reviewText.text = message;
		//TODO: Modify the carets
		Image noteImage1 = reviewCanvas.transform.GetChild (2).GetComponent<Image> ();
		noteImage1.sprite = Resources.Load<Sprite> (friendSprite);

		Image noteImage2 = reviewCanvas.transform.GetChild (3).GetComponent<Image> ();
		noteImage2.sprite = Resources.Load<Sprite> (enemySprites[0]);

		Image noteImage3 = reviewCanvas.transform.GetChild (4).GetComponent<Image> ();
		noteImage3.sprite = Resources.Load<Sprite> (enemySprites[1]);

		Image noteImage4 = reviewCanvas.transform.GetChild (5).GetComponent<Image> ();
		noteImage4.sprite = Resources.Load<Sprite> (enemySprites[2]);

		Image noteImage5 = reviewCanvas.transform.GetChild (6).GetComponent<Image> ();
		noteImage5.sprite = Resources.Load<Sprite> (enemySprites[3]);

		Image noteImage6 = reviewCanvas.transform.GetChild (7).GetComponent<Image> ();
		noteImage6.sprite = Resources.Load<Sprite> (enemySprites[4]);

		Image noteImage7 = reviewCanvas.transform.GetChild (8).GetComponent<Image> ();
		noteImage7.sprite = Resources.Load<Sprite> (enemySprites[5]);


		Text noteText1 = reviewCanvas.transform.GetChild (9).GetComponent<Text> ();
		noteText1.text = friendName;

		Text noteText2 = reviewCanvas.transform.GetChild (10).GetComponent<Text> ();
		noteText2.text = enemyNames[0];

		Text noteText3 = reviewCanvas.transform.GetChild (11).GetComponent<Text> ();
		noteText3.text = enemyNames[1];

		Text noteText4 = reviewCanvas.transform.GetChild (12).GetComponent<Text> ();
		noteText4.text = enemyNames[2];

		Text noteText5 = reviewCanvas.transform.GetChild (13).GetComponent<Text> ();
		noteText5.text = enemyNames[3];

		Text noteText6 = reviewCanvas.transform.GetChild (14).GetComponent<Text> ();
		noteText6.text = enemyNames[4];

		Text noteText7 = reviewCanvas.transform.GetChild (15).GetComponent<Text> ();
		noteText7.text = enemyNames[5];

	
	
	}
}
