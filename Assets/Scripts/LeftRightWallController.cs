using UnityEngine;
using System.Collections;

public class LeftRightWallController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D item) {
		string colliderObject = item.gameObject.name;
		switch (colliderObject) {
		case "Bullet(Clone)":
			Destroy (item.gameObject);
			// What else to do?
			break;
		case "Coin":
			Destroy (item.gameObject);
			Destroy (item.transform.parent.gameObject);
			break;
		default:
			break;
		}
	}

}
