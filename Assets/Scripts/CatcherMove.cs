using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CatcherMove : MonoBehaviour {

	public Transform thePlayer;
	private float PlayerPosX;

	// Use this for initialization
	void Start () {
		PlayerPosX = thePlayer.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (thePlayer.position.x, transform.position.y, transform.position.z);		
	}
}
