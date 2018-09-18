using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverManager : MonoBehaviour {

	public GameObject coverComponent;
	public int width;
	public int height;
	public Vector3Int xPositions;
	public int xthickness;
	public int ythickness;
	public int yHeight;

	List<GameObject> reference = new List<GameObject> ();

	void Start()
	{

	}

	// Subscribe to events 
	void OnEnable()
	{
		MainGameManager.reset += reset;
	}

	// Subscribe to events 
	void OnDisable()
	{
		MainGameManager.reset -= reset;
	}

	// Spawn all the enemies
	void Spawn(int xpos, int ypos)
	{

		// Spawn all the enemies and Position them correctly
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{

				if ((x < xthickness || x >= (width - xthickness)) || y > (height-ythickness))
				{
					GameObject temp = Instantiate (coverComponent);
					temp.transform.position = new Vector3 (xpos + x * 0.1f, ypos + y * 0.1f, 0.0f);
					temp.transform.SetParent (this.transform);
					reference.Add (temp);
				}
			}
		}


	}

	void reset()
	{

		foreach(GameObject obj in reference)
		{
			if(obj != null)
				Destroy (obj);
		}

		reference.Clear ();

		Spawn (xPositions.x, yHeight);
		Spawn (xPositions.y, yHeight);
		Spawn (xPositions.z, yHeight);

	}


}
