/* References */

using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private GameObject bPrefab; 
	private Animator playerAnimator;
	private int score;



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
		score = 0;
		flip = true;
		myRigidBody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();

	}

	public void IncScore(){
		score++;
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
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
			
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
		Destroy(GameObject.Find("Bullet(Clone)"), 1);
		Destroy (GameObject.Find("ExplosionMobile(Clone)"), 2);
		Destroy (GameObject.Find("Explosion(Clone)"), 2);
	}

	private void UpdateScore(){
		//Debug.Log ("Update Score Called!");
		scoreText.GetComponent<GUIText> ().text = "Score : " + score;
	}

}
