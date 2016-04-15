using UnityEngine;
using System.Collections;

public class BonusBoxController : MonoBehaviour {


	/* Private Serialized. */
	[SerializeField]
	private GameObject explodeAnimation;

	[SerializeField]
	private AudioClip caretBlast;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D item) {
		string colliderObject = item.gameObject.name;
		switch (colliderObject) {
		case "Hazel":
			// What happens? Show popup that it's a bonus! TODO
			break;

		case "Bullet(Clone)":
			// Do whatever needs to be done when hit by a bullet.
			Instantiate (explodeAnimation, gameObject.transform.position, Quaternion.identity);
			SoundManager.instance.PlaySingle (caretBlast);
			GameObject.Find ("MovingLadder").GetComponent<MovingLadderController> ().SetLadderSpeed (0.3f);
			Destroy (item.gameObject);
			Destroy (gameObject);
			break;
		default:
			break;

		}
	}



}
