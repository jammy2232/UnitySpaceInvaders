using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager: MonoBehaviour 
{

	// Menu to Control
	public GameObject ControlledMenu;

	// Subscribe to events 
	void OnEnable()
	{
		GameManager.CloseMenu += HideMenu;
		GameManager.ShowMenu += ShowMenu;
	}

	// Subscribe to events 
	void OnDisable()
	{
		GameManager.CloseMenu -= HideMenu;
		GameManager.ShowMenu -= ShowMenu;
	}
		
	// Reset and show the menu items
	void ShowMenu()
	{
		ControlledMenu.SetActive (true);
	}

	void HideMenu()
	{
		ControlledMenu.SetActive (false);
	}
		
}
