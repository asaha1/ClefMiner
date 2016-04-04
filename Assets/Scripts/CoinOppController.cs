using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoinOppController : MonoBehaviour {

	/* Private Fields. */
	private Rigidbody2D coinRb;
	private int dir;

	/* Private Serializables. */
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
				SoundManager.instance.PlaySingle (cointDestroy);
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

	void OnDestroy(){

	}
}
