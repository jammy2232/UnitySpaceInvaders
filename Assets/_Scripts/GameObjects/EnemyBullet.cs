using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public float speed = 10.0f;

	// Subscribe to events 
	void OnEnable()
	{
		InvationWave.complete += DeleteSelf;
		MainGameManager.reset += DeleteSelf;
	}

	// Subscribe to events 
	void OnDisable()
	{
		InvationWave.complete -= DeleteSelf;
		MainGameManager.reset -= DeleteSelf;
	}

	// Update is called once per frame
	void Update ()
	{

		// Move towards the enemies
		transform.position += new Vector3 (0.0f, -speed * Time.deltaTime, 0.0f); 

		// Destroy when out of sight
		if (transform.position.y < 0.0f)
		{
			Destroy (this.gameObject);
		}

	}

	void DeleteSelf()
	{
		Destroy (this.gameObject);
	}

	// Collision And death 
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "cover")
		{
			Destroy (this.gameObject);
		}
	}

}
