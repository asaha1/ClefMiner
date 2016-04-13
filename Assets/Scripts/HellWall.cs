using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HellWall : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D item){
		if (item.gameObject.name == "Hazel") {
			SceneManager.LoadScene (1);
		}
	}
}
