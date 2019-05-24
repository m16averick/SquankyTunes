using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerPlane : MonoBehaviour {

	public PlaneController thePlayer;

	private Vector3 LastPlayerPosition;
	private float distanceToMove;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlaneController>();
		LastPlayerPosition = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		distanceToMove = thePlayer.transform.position.x - LastPlayerPosition.x;

		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);

		LastPlayerPosition = thePlayer.transform.position;

	}
}
