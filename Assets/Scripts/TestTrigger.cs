using UnityEngine;
using System.Collections;

public class TestTrigger : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D item){
		
		if (item.gameObject.name == "Hazel") {
			Debug.Log ("Enter Trigger Himangshu");
			//Instantiate (fireworks);
		}
	}

	void OnTriggerExit2D(Collider2D item){
		if (item.gameObject.name == "Hazel") {
			Debug.Log ("Exit Trigger Himangshu");
		}
	}
}
