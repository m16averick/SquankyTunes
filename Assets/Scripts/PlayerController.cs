using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

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

	public AudioSource jumpSound, deathSound;
	
	
	public string GameMode;

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
		
		GameMode = 	 SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
		
		if ( SceneManager.GetActiveScene().name == "endless")
		{
			

			//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

			grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

			if (transform.position.x > speedMilestoneCount) 
			{
				speedMilestoneCount += speedIncreaseMilestone;
				speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplier;
				moveSpeed = moveSpeed * speedMultiplier;
			}

			myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y);

			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
			{
				if (grounded ) 
				{
					myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);		
					stoppedJumping = false;
					jumpSound.Play ();

				}

				if (!grounded && canDoubleJump) {
					jumpTimeCounter = jumpTime;
					myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);		
					stoppedJumping = false;
					canDoubleJump = false;
					jumpSound.Play ();
				}

			}

			if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) && !stoppedJumping) 
			{
				if (jumpTimeCounter > 0) 
				{
					myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
					jumpTimeCounter -= Time.deltaTime;
				}
			}

			if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) 
			{
				jumpTimeCounter = 0;
				stoppedJumping = true;
			}

			if (grounded) 
			{
				jumpTimeCounter = jumpTime;
				canDoubleJump = true;
			}

			myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
			myAnimator.SetBool ("Grounded", grounded);


		}


	
	
			if ( SceneManager.GetActiveScene().name == "plane")
		{
			

			//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

			

			if (transform.position.x > speedMilestoneCount) 
			{
				speedMilestoneCount += speedIncreaseMilestone;
				speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplier;
				moveSpeed = moveSpeed * speedMultiplier;
			}

			myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y);

			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
			{

					myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);		
					stoppedJumping = false;
					jumpSound.Play ();

				
			}

			myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
			myAnimator.SetBool ("Grounded", grounded);


		}


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
