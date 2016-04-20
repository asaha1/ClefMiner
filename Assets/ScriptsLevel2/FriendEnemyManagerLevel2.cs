using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class FriendEnemyManagerLevel2 : MonoBehaviour {


	public static FriendEnemyManagerLevel2 instance = null;     //Allows other scripts to call functions from FriendEnemyManager.             

	/* Private Serialized. */
	//[SerializeField]
	private string friendName;
	private string friendClip;
	//[SerializeField]
	private string[] enemyNames;
	private string[] enemyClip;

	void Awake ()
	{
		friendName = "NotationsSprites/Notes/" + "G";
		friendClip = "NoteAudios/" + "piano_G";
		enemyNames = new string[6];
		enemyClip = new string[6];

		enemyNames[0] = "NotationsSprites/Notes/" + "A";
		enemyNames[1] = "NotationsSprites/Notes/" + "B";
		enemyNames[2] = "NotationsSprites/Notes/" + "C";
		enemyNames[3] = "NotationsSprites/Notes/" + "D";
		enemyNames[4] = "NotationsSprites/Notes/" + "E";
		enemyNames[5] = "NotationsSprites/Notes/" + "F";

		enemyClip[0] = "NoteAudios/" + "piano_A";
		enemyClip[1] = "NoteAudios/" + "piano_B";
		enemyClip[2] = "NoteAudios/" + "piano_C";
		enemyClip[3] = "NoteAudios/" + "piano_D";
		enemyClip[4] = "NoteAudios/" + "piano_E";
		enemyClip[5] = "NoteAudios/" + "piano_F";

		//Check if there is already an instance of FriendEnemyManager
		if (instance == null)
			//if not, set it to this.
			instance = this;
		//If instance already exists:
		else if (instance != this)
			//Destroy this, this enforces our singleton pattern so there can only be one instance of FriendEnemyManager.
			Destroy (gameObject);

		//Set FriendEnemyManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}


	// Use this for initialization
	void Start () {
		friendName = "NotationsSprites/Notes/" + "G";
		friendClip = "NoteAudios/" + "piano_G";
		enemyNames = new string[6];
		enemyClip = new string[6];

		enemyNames[0] = "NotationsSprites/Notes/" + "A";
		enemyNames[1] = "NotationsSprites/Notes/" + "B";
		enemyNames[2] = "NotationsSprites/Notes/" + "C";
		enemyNames[3] = "NotationsSprites/Notes/" + "D";
		enemyNames[4] = "NotationsSprites/Notes/" + "E";
		enemyNames[5] = "NotationsSprites/Notes/" + "F";

		enemyClip[0] = "NoteAudios/" + "piano_A";
		enemyClip[1] = "NoteAudios/" + "piano_B";
		enemyClip[2] = "NoteAudios/" + "piano_C";
		enemyClip[3] = "NoteAudios/" + "piano_D";
		enemyClip[4] = "NoteAudios/" + "piano_E";
		enemyClip[5] = "NoteAudios/" + "piano_F";
	}


	public string GetFriendName(){
		return friendName;
	}

	public string GetFriendClip(){
		return friendClip;
	}

	public string[] GetEnemyNames(){
		return enemyNames;
	}

	public string[] GetEnemyClips(){
		return enemyClip;
	}
}
