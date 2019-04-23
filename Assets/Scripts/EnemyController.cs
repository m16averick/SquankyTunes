using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour {

private int leftright;
public float moveSpeed;

private Rigidbody2D enemyRigidbody;

	// Use this for initialization
	void Start () {
		enemyRigidbody = GetComponent<Rigidbody2D>();
		leftright = Random.Range(0,2);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (leftright==0)
		{
			enemyRigidbody.velocity = new Vector2(moveSpeed,enemyRigidbody.velocity.y);
		}
		
		if (leftright==1)
		{
			enemyRigidbody.velocity = new Vector2(-moveSpeed,enemyRigidbody.velocity.y);
		}
	}
}
