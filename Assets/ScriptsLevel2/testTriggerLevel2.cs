using UnityEngine;
using System.Collections;

public class TestTriggerLevel2 : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D item){
		
		if (item.gameObject.name == "Hazel") {
			Debug.Log ("ELevel2 nter Trigger Himangshu");
			//Instantiate (fireworks);
		}
	}

	void OnTriggerExit2D(Collider2D item){
		if (item.gameObject.name == "Hazel") {
			Debug.Log ("Level2 Exit Trigger Himangshu");
		}
	}
}
