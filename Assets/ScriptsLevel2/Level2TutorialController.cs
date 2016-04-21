using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2TutorialController : MonoBehaviour {

	public Canvas finalReviewCanvas;
	public Canvas descriptionCanvas;
	public string[] enemyClip;
	public string friendClip;

	// Use this for initialization
	void Start () {
		finalReviewCanvas.enabled = false;
		enemyClip = new string[6];
		friendClip = "NoteAudios/" + "piano_G";
		enemyClip[0] = "NoteAudios/" + "piano_A";
		enemyClip[1] = "NoteAudios/" + "piano_B";
		enemyClip[2] = "NoteAudios/" + "piano_C";
		enemyClip[3] = "NoteAudios/" + "piano_D";
		enemyClip[4] = "NoteAudios/" + "piano_E";
		enemyClip[5] = "NoteAudios/" + "piano_F";
	}

	public void CloseDescription(){
		descriptionCanvas.enabled = false;
		ShowFinalReview ();
	}

	public void ShowDescription(){
		descriptionCanvas.enabled = true;
	}

	public void ShowFinalReview(){
		SetUpReviewCanvas ();
		finalReviewCanvas.enabled = true;
	}

	public void CloseFinalReview(){
		finalReviewCanvas.enabled = false;
		SceneManager.LoadScene (5);
	}

	public void play1(){
		AudioClip tempClip = Resources.Load<AudioClip> (friendClip);
		SoundManagerLevel2.instance.PlaySingleWithVolume (tempClip, 1f);
	}

	public void play2(){
		AudioClip tempClip = Resources.Load<AudioClip> (enemyClip[0]);
		SoundManagerLevel2.instance.PlaySingleWithVolume (tempClip, 1f);
	}

	public void play3(){
		AudioClip tempClip = Resources.Load<AudioClip> (enemyClip[1]);
		SoundManagerLevel2.instance.PlaySingleWithVolume (tempClip, 1f);
	}

	public void play4(){
		AudioClip tempClip = Resources.Load<AudioClip> (enemyClip[2]);
		SoundManagerLevel2.instance.PlaySingleWithVolume (tempClip, 1f);
	}

	public void play5(){
		AudioClip tempClip = Resources.Load<AudioClip> (enemyClip[3]);
		SoundManagerLevel2.instance.PlaySingleWithVolume (tempClip, 1f);
	}

	public void play6(){
		AudioClip tempClip = Resources.Load<AudioClip> (enemyClip[4]);
		SoundManagerLevel2.instance.PlaySingleWithVolume (tempClip, 1f);
	}

	public void play7(){
		AudioClip tempClip = Resources.Load<AudioClip> (enemyClip[5]);
		SoundManagerLevel2.instance.PlaySingleWithVolume (tempClip, 1f);
	}



	public void SetUpReviewCanvas(){
		string[] enemySprites = new string[6];
		string[] enemyNames = new string[6];
		enemySprites[0] = "NotationsSprites/Notes/" + "A";
		enemySprites[1] = "NotationsSprites/Notes/" + "B";
		enemySprites[2] = "NotationsSprites/Notes/" + "C";
		enemySprites[3] = "NotationsSprites/Notes/" + "D";
		enemySprites[4] = "NotationsSprites/Notes/" + "E";
		enemySprites[5] = "NotationsSprites/Notes/" + "F";

		enemyNames [0] = "A Note\nEnemy!";
		enemyNames [1] = "B Note\nEnemy!";
		enemyNames [2] = "C Note\nEnemy!";
		enemyNames [3] = "D Note\nEnemy!";
		enemyNames [4] = "E Note\nEnemy!";
		enemyNames [5] = "F Note\nEnemy!";
		SetUpReviewInternal ("Similar to LEVEL 1, you will identify Notes now !" +
			"\n1st one below is your friend, others enemies\nTouch a friend, shoot an enemy!\nPress the Notes below to hear the Sound and Press OKAY to start!", "NotationsSprites/Notes/G", "G Note\nYour Friend!", enemySprites, enemyNames, "NONE");
	}


	public void SetUpReviewInternal(string message, string friendSprite,string friendName, string[] enemySprites, string[] enemyNames, string kind){
		Text reviewText = finalReviewCanvas.transform.GetChild (1).GetComponent<Text> ();
		reviewText.text = message;
		//TODO: Modify the carets
		Image noteImage1 = finalReviewCanvas.transform.GetChild (2).GetComponent<Image> ();
		noteImage1.sprite = Resources.Load<Sprite> (friendSprite);

		Image noteImage2 = finalReviewCanvas.transform.GetChild (3).GetComponent<Image> ();
		noteImage2.sprite = Resources.Load<Sprite> (enemySprites[0]);

		Image noteImage3 = finalReviewCanvas.transform.GetChild (4).GetComponent<Image> ();
		noteImage3.sprite = Resources.Load<Sprite> (enemySprites[1]);

		Image noteImage4 = finalReviewCanvas.transform.GetChild (5).GetComponent<Image> ();
		noteImage4.sprite = Resources.Load<Sprite> (enemySprites[2]);

		Image noteImage5 = finalReviewCanvas.transform.GetChild (6).GetComponent<Image> ();
		noteImage5.sprite = Resources.Load<Sprite> (enemySprites[3]);

		Image noteImage6 = finalReviewCanvas.transform.GetChild (7).GetComponent<Image> ();
		noteImage6.sprite = Resources.Load<Sprite> (enemySprites[4]);

		Image noteImage7 = finalReviewCanvas.transform.GetChild (8).GetComponent<Image> ();
		noteImage7.sprite = Resources.Load<Sprite> (enemySprites[5]);


		Text noteText1 = finalReviewCanvas.transform.GetChild (9).GetComponent<Text> ();
		noteText1.text = friendName;

		Text noteText2 = finalReviewCanvas.transform.GetChild (10).GetComponent<Text> ();
		noteText2.text = enemyNames[0];

		Text noteText3 = finalReviewCanvas.transform.GetChild (11).GetComponent<Text> ();
		noteText3.text = enemyNames[1];

		Text noteText4 = finalReviewCanvas.transform.GetChild (12).GetComponent<Text> ();
		noteText4.text = enemyNames[2];

		Text noteText5 = finalReviewCanvas.transform.GetChild (13).GetComponent<Text> ();
		noteText5.text = enemyNames[3];

		Text noteText6 = finalReviewCanvas.transform.GetChild (14).GetComponent<Text> ();
		noteText6.text = enemyNames[4];

		Text noteText7 = finalReviewCanvas.transform.GetChild (15).GetComponent<Text> ();
		noteText7.text = enemyNames[5];	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
