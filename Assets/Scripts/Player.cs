/* References */

using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private GameObject bPrefab; 
	private Animator playerAnimator;


	// Scores
	private int hitScore;
	private int falseHitScore;
	private int lifeScore;
	private int boxesScore;



	[SerializeField]
	private int bulletForce;

	[SerializeField]
	private GameObject bulletPrefab;


	[SerializeField]
	private float playerSpeed;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	[SerializeField]
	private GameObject scoreText;

	[SerializeField]
	private AudioClip handgunSound;

	[SerializeField]
	private AudioClip footstep;

	[SerializeField]
	private GameObject explodeAnimation;

	private bool flip;
	private bool isGround;
	private bool jump;
	private bool attack;
	private bool shoot;
	private bool slide;

	//private NoteMineController mineControllerScript;

	[SerializeField]
	private float jumpForce;
	// Use this for initialization
	void Start () {
		hitScore = 0;
		falseHitScore = 0;
		lifeScore = 3;
		boxesScore = 20;
		flip = true;
		myRigidBody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();

	}

	public void IncHitScore(){
		hitScore += 100;
	}

	public void DecHitScore(){
		hitScore -= 50;
	}

	public void IncFalseHitScore(){
		falseHitScore += 100;
	}

	public void DecFalseHitScore(){
		falseHitScore -= 50;
	}



	void Update(){
		HandleInput ();
	}

	// Update is called once per frame
	// Fixed update helps keep updates same across platforms
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		isGround = IsGrounded ();
		Debug.Log (horizontal);
		HandleMoves(horizontal);
		FlipPlayer (horizontal);
		HandleAttacks ();
		HandleLayers ();
		UpdateScore ();
		ResetScene ();
	}

	private void HandleMoves(float horizontal){
		if (myRigidBody.velocity.y < 0) {
			playerAnimator.SetBool ("land", true);
		}

		if (!playerAnimator.GetBool ("slide") && !playerAnimator.GetNextAnimatorStateInfo (0).IsTag ("Attack")) {
			myRigidBody.velocity = new Vector2(horizontal * playerSpeed, myRigidBody.velocity.y);

		}

		playerAnimator.SetFloat ("speed", Mathf.Abs (horizontal));

		if (isGround && jump) {
			isGround = false;
			myRigidBody.AddForce (new Vector2(0, jumpForce));
			playerAnimator.SetTrigger ("jump");
		}
	}

	private void HandleAttacks(){
		if (attack && !playerAnimator.GetNextAnimatorStateInfo (0).IsTag ("Attack")) {
			playerAnimator.SetTrigger ("attack");
			myRigidBody.velocity = Vector2.zero;
		}
		if (shoot) {
			playerAnimator.SetTrigger ("shoot");
			SoundManager.instance.PlaySingle (handgunSound);
			// Fire Bullets here
			ShootBullet();
		}
		if (slide && !playerAnimator.GetNextAnimatorStateInfo (0).IsName ("slide")) {
			playerAnimator.SetBool ("slide", true);
		} else if (!playerAnimator.GetNextAnimatorStateInfo (0).IsName ("slide")) {
			playerAnimator.SetBool ("slide", false);
		}
	}

	private void ShootBullet(){
		//playerAnimator.SetTrigger ("death");
		bPrefab = Instantiate (bulletPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
		Rigidbody2D rb = bPrefab.GetComponent<Rigidbody2D> ();
		if(transform.localScale.x > 0)
			rb.AddForce (gameObject.transform.right * bulletForce);
		else
			rb.AddForce (-gameObject.transform.right * bulletForce);
	}

	private void HandleInput(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump = true;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			ResurrectHazel ();
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
			//SoundManager.instance.RandomizeSfx (footstep);			
		}
		if (Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.Z)) {
			attack = true;
		}
		if (Input.GetKeyDown (KeyCode.RightShift) || Input.GetKeyDown (KeyCode.X)) {
			shoot = true;
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			slide = true;
		}

	}

	public void MurderHazel(){
		playerAnimator.SetTrigger ("death");
		//myRigidBody.isKinematic = true;
	}

	public void ResurrectHazel(){
		//playerAnimator.ResetTrigger ("death");
		playerAnimator.SetTrigger ("resurrect");
	}

	private void FlipPlayer(float hor){
		if (hor > 0 && flip == false || hor < 0 && flip == true) {
			flip = !flip;
			Vector3 myScale = transform.localScale;
			myScale.x *= -1;
			transform.localScale = myScale;			
		}
	}

	private bool IsGrounded(){
		if (true/*myRigidBody.velocity.y <= 0*/) {
			foreach (Transform point in groundPoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {
						playerAnimator.ResetTrigger ("jump");
						playerAnimator.SetBool ("land", false);
						return true;
					}
				}
			}		
		}
		return false;
	}

	private void HandleLayers(){
		if (!isGround) {
			playerAnimator.SetLayerWeight (1, 1);
		} else {
			playerAnimator.SetLayerWeight (1, 0);
		}
	}

	private void ResetScene(){
		jump = false;
		attack = false;
		shoot = false;
		slide = false;
		Destroy(GameObject.Find("Bullet(Clone)"), 0.2f);
		Destroy (GameObject.Find("ExplosionMobile(Clone)"), 2);
		Destroy (GameObject.Find("Explosion(Clone)"), 2);

	}

	private void UpdateScore(){
		//Debug.Log ("Update Score Called!");
		//scoreText.GetComponent<GUIText> ().text = "Score : " + score;
		Text falseHitText = scoreText.transform.GetChild (0).GetComponent<Text> ();
		falseHitText.text = "False Hit Score : " + falseHitScore;
		Text lifeLeftText = scoreText.transform.GetChild (1).GetComponent<Text> ();
		lifeLeftText.text = "Lives Remaining : " + lifeScore;
		Text boxesLeftText = scoreText.transform.GetChild (2).GetComponent<Text> ();
		boxesLeftText.text = "Mines Remaining : " + boxesScore;
		Text hitText = scoreText.transform.GetChild (3).GetComponent<Text> ();
		hitText.text = "True Hits Score : " + hitScore;
	}

}
