using UnityEngine;
using System.Collections;

public class Collider : MonoBehaviour {

	/* Private Varibale Space */
	private BoxCollider2D playerCollider;


	/* Private Serializables */
	[SerializeField]
	private BoxCollider2D platformCollider;
	[SerializeField]
	private BoxCollider2D platformTrigger;


	void Start () {
		playerCollider = GameObject.Find ("Hazel").GetComponent<BoxCollider2D> ();
		Physics2D.IgnoreCollision (platformCollider, platformTrigger, false);
	
	}

	/* For the Jump to platform effect from below the platform. TODO : Check if working properly! */
	void OnTriggerEnter2D(Collider2D item){
		if (item.gameObject.name == "Hazel") {
			//Physics2D.IgnoreCollision (playerCollider, platformCollider, true);
		}
	}

	void OnTriggerExit2D(Collider2D item){
		if (item.gameObject.name == "Hazel") {
			Physics2D.IgnoreCollision (playerCollider, platformCollider, false);
		}
	}

}
