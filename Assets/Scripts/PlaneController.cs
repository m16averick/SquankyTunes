using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

	public float moveSpeed, jumpForce, jumpTime;
	public float speedMultiplier;
	private float moveSpeedStore;

	public float speedIncreaseMilestone;
	public float speedIncreaseMilestoneStore;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;

	private float jumpTimeCounter;

	private bool stoppedJumping;
	private bool canDoubleJump;

	private Rigidbody2D myRigidBody;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	private Collider2D myCollider;

	private Animator myAnimator;

	public GameManager theGameManager;

	public AudioSource jumpSound, jumpSound2, deathSound;
	
	

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();

		myCollider = GetComponent<Collider2D> ();

		myAnimator = GetComponent<Animator> ();

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;

		stoppedJumping = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		


			grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);


			if (transform.position.x > speedMilestoneCount) 
			{
				speedMilestoneCount += speedIncreaseMilestone;
				speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplier;
				moveSpeed = moveSpeed * speedMultiplier;
			}

			myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y);
			//transform.Rotate ( Vector3.forward * transform.position.y );
		transform.eulerAngles = Vector3.forward * transform.position.y * 10 + new Vector3(0,0,18 );
			//.Rotate (Vector3.forward * 1/transform.position.y);


		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0))) {
			if (jumpTimeCounter > 0) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);

				//transform.Rotate (Vector3.forward * 1/2);
				jumpTimeCounter -= Time.deltaTime;
			}
		} /* else if (!grounded){
			transform.Rotate (Vector3.back * 1/2);
		} */
			

			if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) 
			{
				jumpTimeCounter = 0;
				stoppedJumping = true;
			}


			
				jumpTimeCounter = jumpTime;
				canDoubleJump = true;
			

			//myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
			//myAnimator.SetBool ("Grounded", grounded);

		


	}
	
			void OnCollisionEnter2D (Collision2D other)
		{
			if (other.gameObject.tag == "killbox") {
				theGameManager.RestartGame ();
				moveSpeed = moveSpeedStore;
				speedMilestoneCount = speedMilestoneCountStore;
				speedIncreaseMilestone = speedIncreaseMilestoneStore;
				deathSound.Play ();

			}
		}
}
