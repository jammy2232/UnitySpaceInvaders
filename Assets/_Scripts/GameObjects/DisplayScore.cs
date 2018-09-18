using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour 
{

	public Text scoreRef;
	static int scoreTotal = 0;

	// Subscribe to events 
	void OnEnable()
	{
		Invader.death += UpdateScore;
		UFO.death += UpdateScore;
		MainGameManager.reset += reset;
		GameOverManager.scores += UpdateFinalScore;
	}

	// Subscribe to events 
	void OnDisable()
	{
		Invader.death -= UpdateScore;
		UFO.death -= UpdateScore;
		MainGameManager.reset -= reset;
		GameOverManager.scores += UpdateFinalScore;
	}

	// format and update the text
	void UpdateScore(int score)
	{
		scoreTotal += score;
		string scoreBaseText = "SCORE: " + scoreTotal.ToString("D6");
		scoreRef.text = scoreBaseText;
	}

	void UpdateFinalScore()
	{
		string scoreBaseText = "SCORE: " + scoreTotal.ToString("D6");
		scoreRef.text = scoreBaseText;
	}
		
	void reset()
	{
		scoreTotal = 0;
		UpdateScore (0);
	}
}
