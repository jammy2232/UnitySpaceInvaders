using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Interface
	public delegate void ChangeState(GameManager.STATE state);
	public static event ChangeState GameOver;

	public float movementSpeed = 1.0f;
	public float FireCooldownTime = 0.25f;
	float timer;
	Transform bulletSpawn;
	public GameObject bullet;
	public AudioSource source;
	public AudioClip shoot;

	// Subscribe to events 
	void OnEnable()
	{
		InvationWave.complete += levelReset;
	}

	// Subscribe to events 
	void OnDisable()
	{
		InvationWave.complete -= levelReset;
	}

	// Use this for initialization
	void Start () 
	{

		// Get the first transform not the players transform
		bulletSpawn = GetComponentsInChildren<Transform>()[1];

		if (bulletSpawn == null)
		{
			Debug.Log ("Missing bullet spawner");
			Debug.Assert (false);
		}

		// set the timer to stop firing from menu transition
		timer = 0.0f;

	}
	
	// Update is called once per frame
	void Update ()
	{

		// Moveing the player
		float movement = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;

		// Apply the movement if your able to move (Need to check different aspect ratios or lock it)
		if ((transform.position.x + movement) > -8.0f && (transform.position.x + movement) < 8.0f)
		{
			transform.position += new Vector3 (movement, 0.0f, 0.0f);
		}

		// Fire a bullet cooldown timer
		timer += Time.deltaTime;

		// Apply the movement if your able to move
		if (Input.GetButton("Fire"))
		{
			if (timer > FireCooldownTime)
			{
				source.PlayOneShot (shoot);
				GameObject currentBullet = Instantiate (bullet);
				currentBullet.transform.position = bulletSpawn.position;
				timer = 0.0f;
			}

		}
		
	}

	void levelReset()
	{
		transform.position = new Vector3 (0.0f ,transform.position.y , transform.position.z );
		timer = 0.0f;
	}


	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.tag == "invader" || other.gameObject.tag == "enemyBullet")
		{			
			if (GameOver != null)
				GameOver (GameManager.STATE.GameOver);
		}

	}
		
}
