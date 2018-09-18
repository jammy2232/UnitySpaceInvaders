using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotator : MonoBehaviour 
{

	// parameters
	public float speedLower = 15.0f;
	public float speedUpper = 15.0f;
	public float freqency = 1.0f;
	float timer = 0.0f;

	// Update is called once per frame
	void Update () 
	{

		// Time it 
		timer += Time.deltaTime * freqency;
	
		// apply the rotation
		transform.Rotate(0.0f, 0.0f, Mathf.Lerp(speedUpper, speedLower, timer) * Time.deltaTime);

		// Check the magnitude and invert the speed
		if (timer > 1.0f)
		{
			float temp = speedLower;
			speedLower = speedUpper;
			speedUpper = temp;
			timer = 0.0f;
		}			
	}
}
