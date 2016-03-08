using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	private Rigidbody2D coinRb;

	[SerializeField]
	private GameObject coinDestroyAnimation;

	[SerializeField]
	private AudioClip cointDestroy;

	[SerializeField]
	private float coinSpeed;

	// Use this for initialization
	void Start () {
		coinRb = GetComponent<Rigidbody2D> ();
	}


	void Update(){
		if (coinRb.gravityScale > 0) {
			// Make the Note Move. Depending on the type of note, it will be either
			// Towards or away from the player.
		}
	}

	void OnCollisionEnter2D(Collision2D item) {
		// If it collided with a bullet
		if (item.gameObject.name == "Bullet(Clone)") {
			// Destroy itself if the Crate renderer has vanished.
			//Debug.Log ("Gravity Scale : " + coinRb.gravityScale);
			if (coinRb.gravityScale > 0) {
				Instantiate (coinDestroyAnimation, transform.position, Quaternion.identity);
				SoundManager.instance.PlaySingle (cointDestroy);
				Player hz = GameObject.Find ("Hazel").GetComponent<Player> (); 
				hz.IncScore ();
				Destroy(gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
			}
			// And destroy the bullet as well.
			Destroy(item.gameObject);
		}

	}

	void OnDestroy(){
		
	}
}
