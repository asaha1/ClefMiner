using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HellWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D item){
		if (item.gameObject.name == "Hazel") {
			SceneManager.LoadScene ("Level2_G");
		}
	}
}
