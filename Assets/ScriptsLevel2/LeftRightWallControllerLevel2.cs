﻿using UnityEngine;
using System.Collections;

public class LeftRightWallControllerLevel2 : MonoBehaviour {

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
			PlayerLevel2 hz = GameObject.Find ("Hazel").GetComponent<PlayerLevel2> (); 
			if (hz.IsLastBoxOpened ()) {
				hz.ShootGameWon (0.5f);
			}
			Destroy (item.gameObject);
			Destroy (item.transform.parent.gameObject);
			break;
		default:
			break;
		}
	}

}