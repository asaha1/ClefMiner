using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Microsoft.Win32.SafeHandles;

public class CoinOppControllerLevel2 : MonoBehaviour {

	/* Private Fields. */
	private Rigidbody2D coinRb;
	private int dir;
	private SpriteRenderer coinSprite;
	private string noteName;

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
		string[] enemies = FriendEnemyManagerLevel2.instance.GetEnemyNames();
		string[] enemyClips = FriendEnemyManagerLevel2.instance.GetEnemyClips ();
		Random.seed = (int)(gameObject.transform.position.GetHashCode ());
		int enemyId = Random.Range (0, enemies.Length);
		string enemyURL = enemies[enemyId];
		string[] splitNames = enemyURL.Split ('/');
		int i = splitNames.Length;
		Sprite tempSprite = Resources.Load<Sprite> (enemyURL);
		cointDestroy = Resources.Load<AudioClip> (enemyClips [enemyId]);
		coinSprite.sprite = tempSprite;
		noteName = splitNames [i - 1];
		coinRb.constraints = RigidbodyConstraints2D.FreezeRotation;
		isCoinNaked = false;
		coinSpeed = 0;
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
			collider.GetComponent<HintScriptLevel2> ().reloadNextLevelNeeded = true;
			//string currSpriteName = coinSprite.name;
			collider.GetComponent<HintScriptLevel2> ().setHint ("Wow ! You killed the enemy Note.\nClick Okay/Press Enter to go next. ", "NotationsSprites/Others/cool_smiley");
			collider.GetComponent<HintScriptLevel2> ().showHint ();
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
				SoundManagerLevel2.instance.PlaySingleWithVolume (cointDestroy, 1f);
				PlayerLevel2 hz = GameObject.Find ("Hazel").GetComponent<PlayerLevel2> (); 
				hz.IncFalseHitScore ();
				hz.DecHitScore ();
				//hz.MurderHazel ();
				hz.DecLife ();
				string tempMsg = "Oops! The wrong Note [" + noteName + "] has touched you.\nShoot before it does.";
				hz.RepositionHazel (Vector3.zero, false, tempMsg);
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
				collider.GetComponent<HintScriptLevel2> ().reloadLevelNeeded = true;
				collider.GetComponent<HintScriptLevel2> ().setHint ("Oops! The wrong Note [" + noteName + "] has touched you. Shoot before it does.\nClick Okay/Press Enter to try again. ", "NotationsSprites/Others/sad_smiley");
				collider.GetComponent<HintScriptLevel2> ().showHint ();
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
				PlayerLevel2 hz = GameObject.Find ("Hazel").GetComponent<PlayerLevel2> (); 
				hz.IncHitScore ();
				SoundManagerLevel2.instance.PlaySingleWithVolume (cointDestroy, 1f);
				hz.ShootNonBlockingPopup ("Yay ! Correctly Shot Note [" + noteName + "]!", 2f, "NONE");
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
				collider.GetComponent<HintScriptLevel2> ().reloadMain = true;
				//string currSpriteName = coinSprite.name;
				collider.GetComponent<HintScriptLevel2> ().setHint ("Wow ! You killed the enemy Note.\nClick Okay/Press to review the Notes!", "NotationsSprites/Others/cool_smiley");
				collider.GetComponent<HintScriptLevel2> ().showHint ();
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
