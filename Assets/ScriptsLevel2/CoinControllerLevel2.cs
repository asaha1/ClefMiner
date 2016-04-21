using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;
//using UnityEditor.VersionControl;
//using UnityEditor;

public class CoinControllerLevel2 : MonoBehaviour {

	/* Private Variables. */
	private Rigidbody2D coinRb;
	private int dir;
	private SpriteRenderer coinSprite;
	private string noteName;



	/* Private Serializables */
	[SerializeField]
	private float coinSpeed;

	[SerializeField]
	private GameObject coinDestroyAnimation;

	[SerializeField]
	private AudioClip coinDestroy;

	[SerializeField]
	private AudioClip coinTimeoutSound;




	// Use this for initialization
	void Start () {
		coinRb = GetComponent<Rigidbody2D> ();
		coinSprite = GetComponent<SpriteRenderer> ();
		string friendURL = FriendEnemyManagerLevel2.instance.GetFriendName ();
		string[] splitNames = friendURL.Split ('/');
		int i = splitNames.Length;
		Sprite tempSprite = Resources.Load<Sprite> (friendURL);
		Debug.Log ("CoinControllerLevel2 :: Friend URL Is = " + friendURL);
		coinSprite.sprite = tempSprite;
		noteName = splitNames [i - 1];			
		coinDestroy = Resources.Load<AudioClip> (FriendEnemyManagerLevel2.instance.GetFriendClip ());
		coinRb.constraints = RigidbodyConstraints2D.FreezeRotation;
		coinSpeed = 0;
	}

	public void SetDirection(int dirc){
		dir = dirc;
	}

	void Update(){
		if (coinRb.gravityScale > 0) {
			// Make the Note Move. Depending on the type of note, it will be either
			// Towards or away from the player.
			Vector2 newPosition = new Vector2(gameObject.transform.position.x + dir * coinSpeed, gameObject.transform.position.y);
			coinRb.MovePosition (newPosition);
		}
	}

	/*(void FixedUpdate(){
		if (coinRb.gravityScale > 0) {
			float horizontal = Input.GetAxis ("Horizontal");
			coinRb.velocity = new Vector2 (horizontal * 10, coinRb.velocity.y);
		}	
	}*/



	void OnCollisionEnter2D(Collision2D item) {
		string colliderObject = item.gameObject.name;
		switch (colliderObject) {
		case "Hazel":
			// Destroy itself if the Crate renderer has vanished.
			//Debug.Log ("Gravity Scale : " + coinRb.gravityScale);
			if (coinRb.gravityScale > 0) {
				//Instantiate (coinDestroyAnimation, transform.position, Quaternion.identity);
				SoundManagerLevel2.instance.PlaySingleWithVolume (coinDestroy, 0.5f);
				PlayerLevel2 hz = GameObject.Find ("Hazel").GetComponent<PlayerLevel2> (); 
				hz.IncHitScore ();
				hz.ShootNonBlockingPopup ("Yay ! Correct Note " + noteName + " Collected !", 2f,"NONE");
				if (hz.IsLastBoxOpened ()) {
					hz.ShootGameWon (0.5f);
				}
				if (hz.IsDeltaBad ())
					hz.SetReviewActive (true);
				else
					hz.SetReviewActive (false);
				Destroy (gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
				// For tutorial , show bravo
				if (SceneManager.GetActiveScene ().name == "Level1Tutorial_1") {
					// TODO Hint popup saying that you did mistake.
					GameObject collider = GameObject.Find ("TutorialCollider");
					collider.SetActive (true);
					collider.GetComponent<HintScript> ().reloadNextLevelNeeded= true;
					collider.GetComponent<HintScript> ().setHint ("Bravo ! You have identified the correct Note.\nClick Okay/Press Enter for next Tutorials!", "NotationsSprites/Notes/G");
					collider.GetComponent<HintScript> ().showHint ();
				}
			}
			break;
		
		case "Bullet(Clone)":
			// Do whatever needs to be done when hit by a bullet.
			if (coinRb.gravityScale > 0) {
				Instantiate (coinDestroyAnimation, transform.position, Quaternion.identity);
				// Update the scores.
				PlayerLevel2 hz = GameObject.Find ("Hazel").GetComponent<PlayerLevel2> (); 
				hz.DecHitScore ();
				hz.IncFalseHitScore ();
				if (hz.IsDeltaBad ()) {
					hz.SetReviewActive (true);
					hz.ShootNonBlockingPopup ("Oops ! Killing a friend Note " + noteName + " ?" +
					"\nPlease Review The Notes above", 5f, "NONE");
				} else {
					hz.SetReviewActive (false);
					hz.ShootNonBlockingPopup ("Oops ! Killing a friend Note " + noteName + " ?" +
						"Careful !", 5f, "NONE");
				}
				
				
				if (hz.IsLastBoxOpened ()) {
					hz.ShootGameWon (1f);
				}
				Destroy(item.gameObject);
				Destroy (gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
				// For turorial.
				if (SceneManager.GetActiveScene ().name == "Level1Tutorial_1") {
					// TODO Hint popup saying that you did mistake.
					GameObject collider = GameObject.Find ("TutorialCollider");
					collider.SetActive (true);
					collider.GetComponent<HintScript> ().reloadLevelNeeded = true;
					collider.GetComponent<HintScript> ().setHint ("Ooops! You have killed a friend Note [" + noteName + "]!\nPlease try again. Click Okay/Press Enter.", "NotationsSprites/Notes/G");
					collider.GetComponent<HintScript> ().showHint ();
				}
			}
			break;
		default:
			break;			
		}
	}

	public void OnBeforeTimeout(){
		Instantiate (coinDestroyAnimation, transform.position, Quaternion.identity);
		SoundManagerLevel2.instance.PlaySingle (coinTimeoutSound);
		PlayerLevel2 hz = GameObject.Find ("Hazel").GetComponent<PlayerLevel2> (); 
		hz.DecHitScore ();
		if (hz.IsLastBoxOpened ()) {
			hz.ShootGameWon (0.5f);
		}
	}

	void OnDestroy(){
		
	}
}
