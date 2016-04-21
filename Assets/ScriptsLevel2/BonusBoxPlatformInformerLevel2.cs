using UnityEngine;
using System.Collections;

public class BonusBoxPlatformInformerLevel2 : MonoBehaviour {
	[SerializeField]
	private BoxCollider2D verticalCollider;
	void Start () {

	}

	/* For the Jump to platform effect from below the platform. TODO : Check if working properly! */
	void OnTriggerEnter2D(Collider2D item){
		if (item.gameObject.name == "Hazel") {
			item.gameObject.GetComponent<PlayerLevel2> ().ShootNonBlockingPopup ("Please Shoot the Glowing Box" +
				"\nIt will kick start the Lift !", 5f, "SHOW_BG");
			verticalCollider.enabled = false;
		}
	}
}
