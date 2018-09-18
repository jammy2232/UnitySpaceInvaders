using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour {

	public float spawnXPosition = 12.0f;
	public float spawnYPosition = 5.0f;
	public float period = 5.0f;
	public GameObject UFO;

	float timer = 0.0f;


	// Update is called once per frame
	void Update () 
	{

		timer += Time.deltaTime;

		if (timer > period)
		{

			int randomNumber = Random.Range (0, 2);
			timer = 0.0f;

			if (randomNumber == 1)
			{

				GameObject newUFO = Instantiate (UFO);

				// Random Direction and Spawn
				int direction = Random.Range(0, 2);

				if (direction == 0)
					direction = -1;
	
				// Place and set the UFO
				newUFO.transform.position = new Vector3 (spawnXPosition * direction, spawnYPosition, 0.0f);
				newUFO.GetComponent<UFO> ().speed *= -direction;

			}

		}

	}




}
