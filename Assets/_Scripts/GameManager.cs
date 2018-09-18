using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	
	// Game state
	public enum STATE { Start, Menu, Game, GameOver }
	STATE currentState;

	// Game Events 
	public delegate void StateEvent();
	public static event StateEvent EndGame;
	public static event StateEvent CloseGameOver;
	public static event StateEvent CloseMenu;
	public static event StateEvent StartGame;
	public static event StateEvent ShowGameOver;
	public static event StateEvent ShowMenu;

	// Subscribe to events 
	void OnEnable()
	{
		StartMenu.StartGame += ChangeState;
		PlayerController.GameOver += ChangeState;
		GameOverScreen.RestartGame += ChangeState;
		GameControler.QuitToMenu += ChangeState;
	}

	// Subscribe to events 
	void OnDisable()
	{
		StartMenu.StartGame -= ChangeState;
		PlayerController.GameOver -= ChangeState;
		GameOverScreen.RestartGame -= ChangeState;
		GameControler.QuitToMenu -= ChangeState;
	}

	// Show the main menu 
	void Start () 
	{

		// Permanent Object
		DontDestroyOnLoad(this);

		// Hide the Cursor
		Cursor.visible = false;

		// Setup the initial state
		currentState = STATE.Start;	
		ChangeState (STATE.Menu);
	}
	
	// Update the game State
	public void ChangeState (STATE desiredState) 
	{

		// Check if the states changed and updated it so
		if (currentState != desiredState)
		{

			// End the current state
			switch (currentState)
			{
			case STATE.Game:
				if (EndGame != null)
					EndGame ();
				break;
			case STATE.GameOver:
				if (CloseGameOver != null)
					CloseGameOver ();
				break;
			case STATE.Menu:
				if (CloseMenu != null)
					CloseMenu ();
				break;
			default:
				break;
			}

			// Start the new state 
			switch (desiredState)
			{
			case STATE.Game:
				if (StartGame != null)
					StartGame ();
				break;
			case STATE.GameOver:
				if (ShowGameOver != null)
					ShowGameOver ();
				break;
			case STATE.Menu:
				if (ShowMenu != null)
					ShowMenu ();
				break;
			default:
				break;
			}

			// Updated the state
			currentState = desiredState;

		}
			
	}
		
}
