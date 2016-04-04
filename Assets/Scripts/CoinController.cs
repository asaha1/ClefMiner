using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking.Match;

public class CoinController : MonoBehaviour {

	/* Private Variables. */
	private Rigidbody2D coinRb;
	private int dir;



	/* Private Serializables */
	[SerializeField]
	private float coinSpeed;

	[SerializeField]
	private GameObject coinDestroyAnimation;

	[SerializeField]
	private AudioClip coinDestroy;


	// Use this for initialization
	void Start () {
		coinRb = GetComponent<Rigidbody2D> ();
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
				Destroy (gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
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
				Destroy (gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
			}
			break;
		default:
			break;			
		}
	}

	void OnDestroy(){
		
	}
}
