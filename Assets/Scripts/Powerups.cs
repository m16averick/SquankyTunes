﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

	public bool doublePoints;
	public bool safeMode;
	public bool planeMode;

	public float powerupLength;

	private PowerupManager thePowerupManager;

	public Sprite[] powerupSprites;

	// Use this for initialization
	void Start () {
		thePowerupManager = FindObjectOfType<PowerupManager> ();
	}


	
	// Update is called once per frame
	void Awake () {

		int powerupSelector = Random.Range (0, 3);
		switch (powerupSelector) {
		case 0:
			doublePoints = true;
			break;
		case 1:
			safeMode = true;
			break;
		case 2:
			planeMode = true;
			break;

		}

		GetComponent<SpriteRenderer> ().sprite = powerupSprites [powerupSelector];

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			thePowerupManager.ActivatePowerup (doublePoints, safeMode, planeMode, powerupLength);
		}
		gameObject.SetActive (false);
	}

}
