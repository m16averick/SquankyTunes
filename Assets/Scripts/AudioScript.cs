using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

	public AudioClip menu1, menu2;


	public AudioSource MusicSource;


	// Use this for initialization
	void Start () {
		MusicSource.clip = menu1;
		MusicSource.Play ();

	}
	
	// Update is called once per frame
	void Update () {
		if (MusicSource.isPlaying == false) {
			MusicSource.clip = menu2;
			MusicSource.Play ();
		}

	}
}
