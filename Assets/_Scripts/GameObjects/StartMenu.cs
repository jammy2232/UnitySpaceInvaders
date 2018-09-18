using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {

	// Interface
	public delegate void ChangeState(GameManager.STATE state);
	public static event ChangeState StartGame;

	// Update is called once per frame
	void Update () 
	{

		// Check to see if a key has been pressed 
		if (Input.GetButtonDown("Fire"))
		{
			if (StartGame != null)
				StartGame (GameManager.STATE.Game);
		}

		// Check to see if a key has been pressed 
		if (Input.GetButtonDown("Escape"))
		{
			Application.Quit ();
		}

	}
		
}
