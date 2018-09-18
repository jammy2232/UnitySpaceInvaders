using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour {

	float timer = 0.0f;

	// Interface
	public delegate void ChangeState(GameManager.STATE state);
	public static event ChangeState RestartGame;

	// Update is called once per frame
	void Update () 
	{

		timer += Time.deltaTime;

		if (timer > 1.0f)
		{

			// Check to see if a key has been pressed 
			if (Input.GetButtonDown ("Fire"))
			{
				timer = 0.0f;

				if (RestartGame != null)
					RestartGame (GameManager.STATE.Menu);
			}

		}

	}
		
}
