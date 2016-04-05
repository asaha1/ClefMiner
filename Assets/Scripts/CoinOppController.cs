using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Microsoft.Win32.SafeHandles;

public class CoinOppController : MonoBehaviour {

	/* Private Fields. */
	private Rigidbody2D coinRb;
	private int dir;
	private SpriteRenderer coinSprite;

	/* Private Serializables. */
	[SerializeField]
	private float coinSpeed;

	[SerializeField]
	private GameObject coinDestroyAnimation;

	[SerializeField]
	private AudioClip cointDestroy;

	[SerializeField]
	private AudioClip coinTimeoutSound;


	// Use this for initialization
	void Start () {
		coinRb = GetComponent<Rigidbody2D> ();
		coinSprite = GetComponent<SpriteRenderer> ();
		string[] enemies = FriendEnemyManager.instance.GetEnemyNames();
		Random.seed = (int)(gameObject.transform.position.GetHashCode ());
		Sprite tempSprite = Resources.Load<Sprite> (enemies[Random.Range (0, enemies.Length)]);
		//Sprite tempSprite = Resources.Load<Sprite> ("NotationsSprites/Clefs/" + "F_Clef");
		coinSprite.sprite = tempSprite;
	}


	void Update(){
		if (coinRb.gravityScale > 0) {
			// Make the Note Move. Depending on the type of note, it will be either
			// Towards or away from the player.
			Vector2 newPosition = new Vector2(gameObject.transform.position.x - dir * coinSpeed, gameObject.transform.position.y);
			coinRb.MovePosition (newPosition);
		}
	}

	public void SetDirection(int dirc){
		dir = dirc;
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
				//SoundManager.instance.PlaySingle (cointDestroy);
				Player hz = GameObject.Find ("Hazel").GetComponent<Player> (); 
				hz.IncFalseHitScore ();
				hz.DecHitScore ();
				hz.MurderHazel ();
				Destroy(gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
				//Destroy Hazel?
			}
			break;

		case "Bullet(Clone)":
			// Do whatever needs to be done when hit by a bullet.
			if (coinRb.gravityScale > 0) {
				Instantiate (coinDestroyAnimation, transform.position, Quaternion.identity);
				//SceneManager.LoadScene ("Level2_G");
				Destroy(gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
				// +100 hitScore
				Player hz = GameObject.Find ("Hazel").GetComponent<Player> (); 
				hz.IncHitScore ();
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
	}

	void OnDestroy(){
		
	}
}
