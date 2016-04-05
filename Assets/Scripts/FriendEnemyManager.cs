using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class FriendEnemyManager : MonoBehaviour {


	public static FriendEnemyManager instance = null;     //Allows other scripts to call functions from FriendEnemyManager.             

	/* Private Serialized. */
	//[SerializeField]
	private string friendName;
	//[SerializeField]
	private string[] enemyNames;

	void Awake ()
	{
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
		friendName = "NotationsSprites/Clefs/" + "C_Clef";
		enemyNames = new string[2];
		enemyNames[0] = "NotationsSprites/Clefs/" + "F_Clef";
		enemyNames[1] = "NotationsSprites/Clefs/" + "G_Clef";
	}


	public string GetFriendName(){
		return friendName;
	}

	public string[] GetEnemyNames(){
		return enemyNames;
	}
}
