using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevel : MonoBehaviour {

	public Text LevelRef;
	static int levelTotal = 0;

	// Subscribe to events 
	void OnEnable()
	{
		InvationWave.complete += UpdateLevel;
		GameOverManager.scores += UpdatFinalLevel;
	}

	// Subscribe to events 
	void OnDisable()
	{
		InvationWave.complete -= UpdateLevel;
		GameOverManager.scores += UpdatFinalLevel;
	}

	// format and update the text
	void UpdateLevel()
	{
		levelTotal += 1;
		string levelBaseText = "LEVEL: " + levelTotal.ToString("D6");
		LevelRef.text = levelBaseText;
	}

	// format and update the text
	void UpdatFinalLevel()
	{
		string levelBaseText = "LEVEL: " + levelTotal.ToString("D6");
		LevelRef.text = levelBaseText;
	}

	void reset()
	{
		levelTotal = 0;
		string levelBaseText = "LEVEL: " + levelTotal.ToString("D6");
		LevelRef.text = levelBaseText;
	}

}
