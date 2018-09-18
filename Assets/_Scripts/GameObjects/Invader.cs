using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour {

	public int scoreOnKill = 10;

	public delegate void ChangeDirection();
	public static event ChangeDirection ChangeDir;

	public delegate void Died(int score);
	public static event Died death;

	bool dead = false;

	// Update is called once per frame
	void Update ()
	{
		
		if ((transform.position.x) < -8.0f || (transform.position.x) > 8.0f)
		{
			if (ChangeDir != null)
				ChangeDir();
		}
			
	}

	// Collision And death 
	void OnTriggerStay(Collider other)
	{

		if (other.gameObject.tag == "playerBullet" && dead == false)
		{
			dead = true;
			
			if (death != null)
				death (scoreOnKill);
			
			Destroy (this.gameObject);
		}

	}
		
}
