using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour {

	public delegate void ResetALL();
	public static event ResetALL reset;

	// Use this for initialization
	// Menu to Control
	public GameObject UIReference;
	public GameObject GameReference;
	public GameObject PauseScreen;
	public GameObject GameController;

	// Subscribe to events 
	void OnEnable()
	{
		GameManager.StartGame += StartGame;
		GameManager.EndGame += HideGame;
		GameControler.pause += PauseGame;
		GameControler.unpause += UnpauseGame;
	}

	// Subscribe to events 
	void OnDisable()
	{
		GameManager.StartGame -= StartGame;
		GameManager.EndGame -= HideGame;
		GameControler.pause -= PauseGame;
		GameControler.unpause -= UnpauseGame;
	}

	// Reset and show the menu items
	void StartGame()
	{
		UIReference.SetActive (true);
		GameReference.SetActive (true);
		GameController.SetActive (true);

		// Reset Everything
		if (reset != null)
			reset ();
		
	}

	// Reset and show the menu items
	void PauseGame()
	{
		UIReference.SetActive (false);
		GameReference.SetActive (false);
		PauseScreen.SetActive (true);
	}

	void UnpauseGame()
	{
		UIReference.SetActive (true);
		GameReference.SetActive (true);
		PauseScreen.SetActive (false);
	}

	void HideGame()
	{
		UIReference.SetActive (false);
		GameReference.SetActive (false);
		GameController.SetActive (false);
		PauseScreen.SetActive (false);
	}


}
