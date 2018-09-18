using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverComponent : MonoBehaviour 
{

	// Nondestructive component
	MeshRenderer renderer;
	BoxCollider col;

	// Use this for initialization
	void Start () 
	{
		renderer = GetComponent<MeshRenderer> ();
		col = GetComponent<BoxCollider> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "enemyBullet" || other.gameObject.tag == "playerBullet" || other.gameObject.tag == "invader")
		{
			renderer.enabled = false;
			col.enabled = false;
		}
	}
		
}
