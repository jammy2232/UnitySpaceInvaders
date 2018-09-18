using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	public AudioClip invaderdeath;
	public AudioClip UFODeath;
	public AudioSource source;

	// Subscribe to events 
	void OnEnable()
	{
		Invader.death += InvaderDeathSound;
		UFO.death += UFODeathSound;
	}

	// Subscribe to events 
	void OnDisable()
	{
		Invader.death -= InvaderDeathSound;
		UFO.death -= UFODeathSound;
	}

	void InvaderDeathSound(int score)
	{
		source.PlayOneShot (invaderdeath);
	}

	void UFODeathSound(int score)
	{
		source.PlayOneShot (UFODeath);
	}


}
