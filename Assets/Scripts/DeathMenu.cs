using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;

	public void RestartGame()
	{
		//FindObjectOfType<GameManager>().Reset ();
		Application.LoadLevel ("endless");
	}

	public void RestartPlane()
	{
		FindObjectOfType<GameManager> ().Reset ();
		Application.LoadLevel ("endless");
	}

	public void QuitToMain()
	{
		Application.LoadLevel (mainMenuLevel);
	}


}
