using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

	public delegate void getScores();
	public static event getScores scores;

	// Use this for initialization
	// Menu to Control
	public GameObject GameOverScreen;

	// Subscribe to events 
	void OnEnable()
	{
		GameManager.ShowGameOver += ShowGameOver;
		GameManager.CloseGameOver += HideGameOver;
	}

	// Subscribe to events 
	void OnDisable()
	{
		GameManager.ShowGameOver -= ShowGameOver;
		GameManager.CloseGameOver -= HideGameOver;
	}

	// Reset and show the menu items
	void ShowGameOver()
	{
		GameOverScreen.SetActive (true);

		if (scores != null)
			scores ();

	}

	void HideGameOver()
	{
		GameOverScreen.SetActive (false);
	}
}
