using UnityEngine;
using System.Collections;

public class Collider : MonoBehaviour {

	private BoxCollider2D playerCollider;

	[SerializeField]
	private BoxCollider2D platformCollider;

	[SerializeField]
	private BoxCollider2D platformTrigger;

	// Use this for initialization
	void Start () {
		playerCollider = GameObject.Find ("Hazel").GetComponent<BoxCollider2D> ();
		Physics2D.IgnoreCollision (platformCollider, platformTrigger, true);
	
	}
	
	void OnTriggerEnter2D(Collider2D item){
		if (item.gameObject.name == "Hazel") {
			Physics2D.IgnoreCollision (playerCollider, platformCollider, true);
		}
	}

	void OnTriggerExit2D(Collider2D item){
		if (item.gameObject.name == "Hazel") {
			Physics2D.IgnoreCollision (playerCollider, platformCollider, false);
		}
	}

}
