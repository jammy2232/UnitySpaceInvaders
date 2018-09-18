using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour {

	// Interface
	public delegate void ChangeState(GameManager.STATE state);
	public static event ChangeState QuitToMenu;

	public delegate void PauseGame();
	public static event PauseGame pause;

	public delegate void UnPause();
	public static event UnPause unpause;

	bool paused = false;

	void Update()
	{

		if (Input.GetButtonDown ("Escape"))
		{
			if (paused)
			{
				if (unpause != null)
					unpause();

				paused = false;

			} else
			{
				if (pause != null)
					pause ();

				paused = true;
			}
		}
			
		if (Input.GetButtonDown ("Fire") && paused)
		{

			paused = false;

			if (QuitToMenu != null)
				QuitToMenu (GameManager.STATE.Menu);
		}

	}

}
