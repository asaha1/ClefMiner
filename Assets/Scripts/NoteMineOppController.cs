using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NoteMineOppController : MonoBehaviour {
	/* Private Fields. */
	private Renderer caretRenderer;
	private Renderer coinRenderer;
	private BoxCollider2D[] noteMineColliders;

	/* Private Serialized. */
	[SerializeField]
	private GameObject explodeAnimation;

	[SerializeField]
	private AudioClip caretBlast;


	// Use this for initialization
	void Start () {
		caretRenderer = gameObject.transform.GetChild (1).GetComponent<Renderer> ();
		coinRenderer = gameObject.transform.GetChild (0).GetComponent<Renderer> ();
		noteMineColliders = GetComponents<BoxCollider2D> ();
	}


	public void VanishCoin(){
		if (!caretRenderer.enabled) {		
			Instantiate (explodeAnimation, gameObject.transform.GetChild (0).transform.position, Quaternion.identity);
			coinRenderer.enabled = false;
		}
	}

	public void UnlockMine(){
		if (caretRenderer.enabled) {
			Instantiate (explodeAnimation, gameObject.transform.position, Quaternion.identity);
			SoundManager.instance.PlaySingle (caretBlast);
			caretRenderer.enabled = false;
			gameObject.transform.GetChild (0).GetComponent<Rigidbody2D> ().gravityScale = 10;
			gameObject.transform.GetChild (0).GetComponent<CoinOppController> ().isCoinNaked = true;
			//gameObject.transform.GetChild (0).GetComponent<Rigidbody2D> ().isKinematic = true;
			// Disable the left and right colliders
			for (int i = 0; i< noteMineColliders.Length;i++){
				Destroy (noteMineColliders[i]);
			}

			// Set the direction of the coin movement.
			Transform playerTransform = GameObject.Find ("Hazel").GetComponent<Transform> ();
			if (playerTransform.position.x < gameObject.transform.position.x)
				gameObject.transform.GetChild (0).GetComponent<CoinOppController> ().SetDirection(1);
			else
				gameObject.transform.GetChild (0).GetComponent<CoinOppController> ().SetDirection(-1);

			// Set the timeout for the coin, then destroy.
			StartCoroutine (TimeoutForCoin ());

			// Decrease the mine counter.
			GameObject.Find ("Hazel").GetComponent<Player> ().DecMines ();
		}
		//if the first block is hit display hint after 1 sec
		if (gameObject.transform.name.Equals("NoteMineOppTutorial") && (SceneManager.GetActiveScene ().name != "Level1")) {
			StartCoroutine (Wait (0.5f));
		}
	}


	IEnumerator Wait(float duration) {
		yield return new WaitForSeconds(duration);   //Wait
		GameObject collider = GameObject.Find ("TutorialCollider");
		collider.SetActive (true);
		string enemyName = gameObject.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite.name;
		collider.GetComponent<HintScript> ().setHint ("This is a " + enemyName  + ". This is an opponent for you.\nThis will come towards you\nShoot it before it touches!", "NotationsSprites/Clefs/"+enemyName);
		collider.GetComponent<HintScript> ().showHint ();
	}


	IEnumerator TimeoutForCoin(){
		yield return new WaitForSeconds(5);
		// Call the OnBeforeTimeout for its child Coin.
		if (gameObject) {
			gameObject.transform.GetChild (0).GetComponent<CoinOppController> ().OnBeforeTimeout ();
			Destroy (gameObject.transform.GetChild (0).gameObject);
		}
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D item){
		Debug.Log ("Trigger Enter!");
		if (item.gameObject.name == "Bullet(Clone)") {
			UnlockMine ();
			Destroy(item.gameObject);
		}
	}

}
