using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;
//using UnityEditor.VersionControl;
//using UnityEditor;

public class CoinController : MonoBehaviour {

	/* Private Variables. */
	private Rigidbody2D coinRb;
	private int dir;
	private SpriteRenderer coinSprite;



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
		Sprite tempSprite = Resources.Load<Sprite> (FriendEnemyManager.instance.GetFriendName());
		//Sprite tempSprite = Resources.Load<Sprite> ("NotationsSprites/Clefs/" + "C_Clef");
		//Debug.Log ("Friend Is = " + FriendEnemyManager.instance.GetFriendName());
		coinSprite.sprite = tempSprite;
		coinRb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
				SoundManager.instance.PlaySingle (coinDestroy);
				Player hz = GameObject.Find ("Hazel").GetComponent<Player> (); 
				hz.IncHitScore ();
				if (hz.IsLastBoxOpened ()) {
					hz.ShootGameWon (0.5f);
				}
				Destroy (gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
				// For tutorial , show bravo
				if (SceneManager.GetActiveScene ().name == "Level1Tutorial_1") {
					// TODO Hint popup saying that you did mistake.
					GameObject collider = GameObject.Find ("TutorialCollider");
					collider.SetActive (true);
					collider.GetComponent<HintScript> ().reloadNextLevelNeeded= true;
					collider.GetComponent<HintScript> ().setHint ("Bravo ! You have identified the correct clef.\nClick Okay/Presss Enter to go next.", "NotationsSprites/Clefs/C_Clef");
					collider.GetComponent<HintScript> ().showHint ();
				}
			}
			break;
		
		case "Bullet(Clone)":
			// Do whatever needs to be done when hit by a bullet.
			if (coinRb.gravityScale > 0) {
				Instantiate (coinDestroyAnimation, transform.position, Quaternion.identity);
				// Update the scores.
				Player hz = GameObject.Find ("Hazel").GetComponent<Player> (); 
				hz.DecHitScore ();
				hz.IncFalseHitScore ();
				if (hz.IsLastBoxOpened ()) {
					hz.ShootGameWon (1f);
				}
				Destroy (gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
				// For turorial.
				if (SceneManager.GetActiveScene ().name == "Level1Tutorial_1") {
					// TODO Hint popup saying that you did mistake.
					GameObject collider = GameObject.Find ("TutorialCollider");
					collider.SetActive (true);
					collider.GetComponent<HintScript> ().reloadLevelNeeded = true;
					collider.GetComponent<HintScript> ().setHint ("Ooops! You have killed a friend Clef!\nPlease try again. Click Okay/Press Enter.", "NotationsSprites/Clefs/C_Clef");
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
		SoundManager.instance.PlaySingle (coinTimeoutSound);
		Player hz = GameObject.Find ("Hazel").GetComponent<Player> (); 
		hz.DecHitScore ();
		if (hz.IsLastBoxOpened ()) {
			hz.ShootGameWon (0.5f);
		}
	}

	void OnDestroy(){
		
	}
}
