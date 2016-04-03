using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoinOppController : MonoBehaviour {

	private Rigidbody2D coinRb;

	[SerializeField]
	private float coinSpeed;

	[SerializeField]
	private GameObject coinDestroyAnimation;

	[SerializeField]
	private AudioClip cointDestroy;


	// Use this for initialization
	void Start () {
		coinRb = GetComponent<Rigidbody2D> ();
	}


	void Update(){
		if (coinRb.gravityScale > 0) {
			// Make the Note Move. Depending on the type of note, it will be either
			// Towards or away from the player.
			Vector2 newPosition = new Vector2(gameObject.transform.position.x - coinSpeed, gameObject.transform.position.y);

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

		if (item.gameObject.name == "Bullet(Clone)") {
			if (coinRb.gravityScale > 0) {
				Instantiate (coinDestroyAnimation, transform.position, Quaternion.identity);
				//SceneManager.LoadScene ("Level2_G");
				Destroy(gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
			}
		}


		// If it collided with a bullet
		if (item.gameObject.name == "Hazel" /*|| item.gameObject.name == "Bullet(Clone)"*/) {
			// Destroy itself if the Crate renderer has vanished.
			//Debug.Log ("Gravity Scale : " + coinRb.gravityScale);
			if (coinRb.gravityScale > 0) {
				//Instantiate (coinDestroyAnimation, transform.position, Quaternion.identity);
				SoundManager.instance.PlaySingle (cointDestroy);
				Player hz = GameObject.Find ("Hazel").GetComponent<Player> (); 
				hz.IncFalseHitScore ();
				//hz.DecHitScore ();
				hz.MurderHazel ();
				//yield return new WaitForSeconds(2);
				// Wait for some time
				//hz.ResurrectHazel ();

				//SceneManager.LoadScene ("Level2_G");
				Destroy(gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
				//Destroy Hazel

			}


			// And destroy the bullet as well.
			//Destroy(item.gameObject);
		}

	}

	void OnDestroy(){

	}
}
