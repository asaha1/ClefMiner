using UnityEngine;
using System.Collections;

public class MovingLadderController : MonoBehaviour {
	[SerializeField]
	private float yMin;

	[SerializeField]
	private float yMax;

	[SerializeField]
	private float ladderSpeed;

	private int ladderDirection;
	private Rigidbody2D ladderBody;

	// Use this for initialization
	void Start () {
		ladderBody = GetComponent<Rigidbody2D> ();
		ladderDirection = -1;
	}


	public void SetLadderSpeed(float speed){
		ladderSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("The Y val = " + gameObject.transform.position.y);
		//Debug.Log ("The yMax = " + yMax);
		if (gameObject.transform.position.y > yMax)
			ladderDirection = -1;
		if (gameObject.transform.position.y < yMin)
			ladderDirection = +1;
		Vector2 newPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + ladderSpeed * ladderDirection);
		ladderBody.MovePosition (newPosition);
	}

	void OnCollisionEnter2D(Collision2D item) {
		string colliderObject = item.gameObject.name;
		switch (colliderObject) {
		case "Hazel":
			if (gameObject.transform.position.y > item.gameObject.transform.position.y) {
				Player hz = GameObject.Find ("Hazel").GetComponent<Player> ();
				ladderDirection = ladderDirection * (-1);
				hz.MurderHazel ();
			}
			break;
		default:
			break;			
		}
	}
}
