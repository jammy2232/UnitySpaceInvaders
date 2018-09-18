using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {

	public int scoreOnKill = 10;
	public float speed = 10.0f;

	public delegate void Died(int score);
	public static event Died death;

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

		transform.position += new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f);

		if ((transform.position.x) < -15.0f || (transform.position.x) > 15.0f)
		{
			Destroy (this.gameObject);
		}

	}

	void DeleteSelf()
	{
		Destroy (this.gameObject);
	}

	// Collision And death 
	void OnTriggerStay(Collider other)
	{

		if (other.gameObject.tag == "playerBullet")
		{
			if (death != null)
				death (scoreOnKill);
			Destroy (this.gameObject);
		}

	}


}
