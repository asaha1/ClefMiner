/* References */

using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private Animator playerAnimator;
	//private BoxCollider2D playerBodyCollider;
	private AudioSource playerSounds;
	private int score;

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

	private bool flip;
	private bool isGround;
	private bool jump;
	private bool attack;
	private bool shoot;
	private bool slide;

	[SerializeField]
	private float jumpForce;
	// Use this for initialization
	void Start () {
		score = 0;
		flip = true;
		myRigidBody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
		//playerBodyCollider = GetComponent<BoxCollider2D> ();
		playerSounds = GetComponent<AudioSource> ();
	}

	public void incScore(){
		score++;
	}

	void Update(){
		handleInput ();
	}

	// Update is called once per frame
	// Fixed update helps keep updates same across platforms
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		isGround = isGrounded ();
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
			//playerSounds.Play ();
		}
	}

	private void HandleAttacks(){
		if (attack && !playerAnimator.GetNextAnimatorStateInfo (0).IsTag ("Attack")) {
			playerAnimator.SetTrigger ("attack");
			myRigidBody.velocity = Vector2.zero;
		}
		if (shoot) {
			playerAnimator.SetTrigger ("shoot");
		}
		if (slide && !playerAnimator.GetNextAnimatorStateInfo (0).IsName ("slide")) {
			playerAnimator.SetBool ("slide", true);
		} else if (!playerAnimator.GetNextAnimatorStateInfo (0).IsName ("slide")) {
			playerAnimator.SetBool ("slide", false);
		}
	}

	private void handleInput(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump = true;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
			
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			attack = true;
		}
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			shoot = true;
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			slide = true;
		}

	}



	private void FlipPlayer(float hor){
		if (hor > 0 && flip == false || hor < 0 && flip == true) {
			flip = !flip;
			Vector3 myScale = transform.localScale;
			myScale.x *= -1;
			transform.localScale = myScale;			
		}
	}

	private bool isGrounded(){
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
	}

	private void UpdateScore(){
		Debug.Log ("Update Score Called!");
		scoreText.GetComponent<GUIText> ().text = "Hazel's Score : " + score;
	}

}
