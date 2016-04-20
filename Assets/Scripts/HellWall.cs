using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HellWall : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D item){
		//fix this just don't load the scene keep the current state
		string colliderObject = item.gameObject.name;
		switch (colliderObject) {
		case "Hazel":
			//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			// What else to do?
			PlayerLevel2 hz = item.gameObject.GetComponent<PlayerLevel2> (); 
			hz.DecLife ();
			hz.RepositionHazel (Vector3.zero, true, null);
			break;
		case "Coin":
			if ((SceneManager.GetActiveScene ().name == "Level1Tutorial_1") || ((SceneManager.GetActiveScene ().name == "Level1Tutorial_2"))) {
				// TODO Hint popup saying that you did mistake.
				GameObject collider = GameObject.Find ("TutorialCollider");
				collider.SetActive (true);
				collider.GetComponent<HintScript> ().reloadLevelNeeded = true;
				collider.GetComponent<HintScript> ().setHint ("Oops! The Clef has fallen !\nTake an action before it falls.\nClick Okay/Press Enter to try again. ", "NotationsSprites/Others/sad_smiley");
				collider.GetComponent<HintScript> ().showHint ();
				Destroy (item.gameObject);
				Destroy (item.transform.parent.gameObject);
				//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
			break;
		default:
			break;
		}
	}
}
