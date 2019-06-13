using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPoints : MonoBehaviour {

	public int scoreToGive;

	private ScoreManager theScoreManager;

	private ParticleSystem particle;

	private AudioSource coinSound;

	SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager>();

		coinSound = GameObject.Find ("CoinSound").GetComponent<AudioSource>();

		rend = this.gameObject.GetComponent<SpriteRenderer> ();
	}
	
	private void Awake() {
		particle = GetComponentInChildren<ParticleSystem> ();
	}

	// Update is called once per frame
	void Update () {
		
	}



	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
				{
			
			theScoreManager.AddScore(scoreToGive);
			StartCoroutine (Break ());
			//gameObject.SetActive (false);
			
			if (coinSound.isPlaying) {
				coinSound.Stop ();

			}
			coinSound.Play ();
				}
	}

	private IEnumerator Break() {
		particle.Play ();
		//gameObject.SetActive (false);
		rend.enabled = !rend.enabled;
		//GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
		yield return new WaitForSeconds (particle.main.startLifetime.constantMax);
		//Destroy (gameObject);
		rend.enabled = !rend.enabled;
		gameObject.SetActive (false);
	}
}