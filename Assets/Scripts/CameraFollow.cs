using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	/* Private Serializables. */
	/* Set these values by dragging the camera to the xtremes. */
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float xMax;
	[SerializeField]
	private float yMin;
	[SerializeField]
	private float yMax;


	/* Private Varibales. */
	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Hazel").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (Mathf.Clamp (target.position.x, xMin, xMax), Mathf.Clamp (target.position.y, yMin, yMax), transform.position.z);
	}
}
