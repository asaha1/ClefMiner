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

	public bool isCoinNaked;


	// Use this for initialization
	void Start () {
		coinRb = GetComponent<Rigidbody2D> ();
		coinSprite = GetComponent<SpriteRenderer> ();
		string[] enemies = FriendEnemyManager.instance.GetEnemyNames();
		Random.seed = (int)(gameObject.transform.position.GetHashCode ());
		Sprite tempSprite = Resources.Load<Sprite> (enemies[Random.Range (0, enemies.Length)]);
		//Sprite tempSprite = Resources.Load<Sprite> ("NotationsSprites/Clefs/" + "F_Clef");
		coinSprite.sprite = tempSprite;
		coinRb.constraints = RigidbodyConstraints2D.FreezeRotation;
		isCoinNaked = false;
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

	IEnumerator ShowTutorialBravo(float duration){
		yield return new WaitForSeconds(duration);   //Wait
		if ((SceneManager.GetActiveScene ().name == "Level1Tutorial_1") || ((SceneManager.GetActiveScene ().name == "Level1Tutorial_2"))) {
			// TODO Hint popup saying that you did mistake.
			GameObject collider = GameObject.Find ("TutorialCollider");
			collider.SetActive (true);
			collider.GetComponent<HintScript> ().reloadNextLevelNeeded = true;
			//string currSpriteName = coinSprite.name;
			collider.GetComponent<HintScript> ().setHint ("Wow ! You killed the enemy Clef.\nClick Okay/Press Enter to go next. ", "NotationsSprites/Others/cool_smiley");
			collider.GetComponent<HintScript> ().showHint ();
		}
	}
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
				//hz.MurderHazel ();
				hz.DecLife ();
				hz.RepositionHazel (Vector3.zero);
				if (hz.IsLastBoxOpened ()) {
					hz.ShootGameWon (0.5f);
				}
				Destroy(gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
				//Destroy Hazel?
			}

			if ((SceneManager.GetActiveScene ().name == "Level1Tutorial_1") || ((SceneManager.GetActiveScene ().name == "Level1Tutorial_2"))) {
				// TODO Hint popup saying that you did mistake.
				GameObject collider = GameObject.Find ("TutorialCollider");
				collider.SetActive (true);
				collider.GetComponent<HintScript> ().reloadLevelNeeded = true;
				collider.GetComponent<HintScript> ().setHint ("Oops! The wrong Clef has touched you. Shoot before it does.\nClick Okay/Press Enter to try again. ", "NotationsSprites/Others/sad_smiley");
				collider.GetComponent<HintScript> ().showHint ();
			}
			break;

		case "Bullet(Clone)":
			// Do whatever needs to be done when hit by a bullet.
			if (coinRb.gravityScale > 0) {
				Instantiate (coinDestroyAnimation, transform.position, Quaternion.identity);
				//SceneManager.LoadScene ("Level2_G");
				Destroy(item.gameObject);
				Destroy(gameObject);
				// Need to destroy it's parent.
				Destroy (transform.parent.gameObject);
				// +100 hitScore
				Player hz = GameObject.Find ("Hazel").GetComponent<Player> (); 
				hz.IncHitScore ();
				hz.ShootNonBlockingPopup ("Yay ! Correct Shot !", 2f);
				if (hz.IsLastBoxOpened ()) {
					hz.ShootGameWon (0.5f);
				}
			}

			//Bravo Tutorial.
			//StartCoroutine (ShowTutorialBravo (0.5f));
			if (isCoinNaked && ((SceneManager.GetActiveScene ().name == "Level1Tutorial_1") || ((SceneManager.GetActiveScene ().name == "Level1Tutorial_2")))) {
				// TODO Hint popup saying that you did mistake.
				GameObject collider = GameObject.Find ("TutorialCollider");
				collider.SetActive (true);
				collider.GetComponent<HintScript> ().reloadMain = true;
				//string currSpriteName = coinSprite.name;
				collider.GetComponent<HintScript> ().setHint ("Wow ! You killed the enemy Clef.\nClick Okay/Press to review the Clefs!", "NotationsSprites/Others/cool_smiley");
				collider.GetComponent<HintScript> ().showHint ();
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
