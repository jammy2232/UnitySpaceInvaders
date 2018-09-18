using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvationWave : MonoBehaviour 
{

	public delegate void levelComplete();
	public static event levelComplete complete;

	// Initial starting positions 
	public Vector3 topLeft;
	public static int numberOfRows = 5;
	public static int numberOfColumns = 11;
	public List<GameObject> types = new  List<GameObject>(); 
	public GameObject EnemyReference;
	public float startingSpeedFreq = 1.0f;
	public float distanceJump = 0.3f;
	public float dropDistance = 0.5f;
	public float changeToReturnFire = 0.1f;
	public GameObject enemyBullet;
	public AudioClip[] music = new AudioClip[4]; 
	public AudioSource source;

	int musicTracker = 0;
	float timer = 0.0f;
	float startingSpeedFreqMod = 1.0f;
	Vector3 movement = new Vector3 (1.0f, 0.0f, 0.0f);
	int AliensAlive = numberOfRows * numberOfColumns;
	float levelDiff = 1.0f;
	GameObject[] shootingEnemies = new GameObject[numberOfColumns];

	// Invaders (max number of 55 invaders (11 * 5)
	GameObject[] invaders = new GameObject[numberOfRows * numberOfColumns];

	// Subscribe to events 
	void OnEnable()
	{
		MainGameManager.reset += Spawn;
		MainGameManager.reset += ResetDifficulty;
		Invader.ChangeDir += ChangeDirection;
		Invader.death += UpdateInvaderReferences;

	}

	// Subscribe to events 
	void OnDisable()
	{
		MainGameManager.reset -= Spawn;
		MainGameManager.reset -= ResetDifficulty;
		Invader.ChangeDir -= ChangeDirection;
		Invader.death -= UpdateInvaderReferences;

	}

	// Update is called once per frame
	void Update () 
	{

		timer += Time.deltaTime;

		if (timer > startingSpeedFreq*startingSpeedFreqMod*levelDiff)
		{

			// Play a sound
			source.PlayOneShot(music[musicTracker]);

			musicTracker++;

			if (musicTracker == music.Length)
				musicTracker = 1;

			EnemyReference.transform.position += movement * distanceJump;

			timer = 0.0f;
		}

		// See if an alien fires back 10% of the time starting difficulty
		if (Random.Range (0.0f, 20000.0f) * levelDiff < (20000.0f * changeToReturnFire))
		{

			GameObject enemyToFire = shootingEnemies [Random.Range (0, numberOfColumns)];

			if(enemyToFire != null)
			{
				GameObject currentBullet = Instantiate (enemyBullet);
				currentBullet.transform.position = enemyToFire.transform.position; 
			}
		}
			
	}

	void UpdateInvaderReferences(int score)
	{
		AliensAlive -= 1;

		if (AliensAlive == 0)
		{
			
			if (complete != null)
				complete ();

			levelDiff += 0.1f;

			// Reset 
			Spawn();

		}

		// Update the speed
		startingSpeedFreqMod = (float)AliensAlive/(numberOfRows * numberOfColumns);

		// recalculate the lowests aliens
		calculateLowestAlien();

	}

	// Change the movement direction
	void ChangeDirection()
	{

		distanceJump = -distanceJump;
		EnemyReference.transform.position += movement * distanceJump;
		EnemyReference.transform.position -= new Vector3 (0.0f, dropDistance, 0.0f);

	}

	// Spawn all the enemies
	void Spawn()
	{

		int index = 0;
		int shootIndex = 0;

		// Reset the number alive
		AliensAlive = numberOfRows * numberOfColumns;
	
		// Reset the enemyReferemce
		EnemyReference.transform.position = new Vector3(0.0f,0.0f,0.0f);

		// Spawn all the enemies and Position them correctly
		for (int y = (int)topLeft.y; y > (topLeft.y - numberOfRows); y--)
		{
			for (int x = (int)topLeft.x; x < (numberOfColumns + topLeft.x); x++)
			{
				invaders [index] = Instantiate (types [0]); 
				invaders [index].transform.position = new Vector3 ((float)x, (float)y, 0.0f);
				invaders [index].transform.SetParent (EnemyReference.transform);

				if(y == ((int)topLeft.y - numberOfRows) + 1)
				{
					shootingEnemies[shootIndex] = invaders [index];
					shootIndex++;
				}

				index++;
			}
		}
	}



	void calculateLowestAlien()
	{
		for (int x = 0; x < numberOfColumns; x++)
		{
			for (int y=0; y < numberOfRows; y++)
			{
				if (invaders [y * numberOfColumns + x] != null)
				{
					shootingEnemies[x] = invaders [y * numberOfColumns + x];
				}
			}
		}
	}


	void ResetDifficulty()
	{
		musicTracker = 0;
		timer = 0.0f;
		startingSpeedFreqMod = 1.0f;
		levelDiff = 1.0f;
	}

}
