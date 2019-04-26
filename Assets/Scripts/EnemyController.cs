using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour {

private bool movingRight = true;
public float moveSpeed;

private Rigidbody2D enemyRigidbody;
public Transform groundDetection;
public float distance;

	// Use this for initialization
	void Start () {
		enemyRigidbody = GetComponent<Rigidbody2D>();

		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);

		//leftright = theEnemyCollider.leftrightnew;
		RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

		if (groundInfo.collider == false) {
			if (movingRight == true) {
				transform.eulerAngles = new Vector3 (0, -180, 0);
				movingRight = false;
			}
			else {
				transform.eulerAngles = new Vector3 (0, 0, 0);
				movingRight = true;
			}
		}


}
}