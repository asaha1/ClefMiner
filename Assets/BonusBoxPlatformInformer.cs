using UnityEngine;
using System.Collections;

public class BonusBoxPlatformInformer : MonoBehaviour {
	[SerializeField]
	private BoxCollider2D verticalCollider;
	void Start () {

	}

	/* For the Jump to platform effect from below the platform. TODO : Check if working properly! */
	void OnTriggerEnter2D(Collider2D item){
		if (item.gameObject.name == "Hazel") {
			item.gameObject.GetComponent<Player> ().ShootNonBlockingPopup ("Please Shoot the Glowing Box to start the Lift !", 10f);
			verticalCollider.enabled = false;
		}
	}
}
