using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

	Queue<GameObject> Voxels = new Queue<GameObject>(); 

	float leftBorder;
	float rightBorder;

	// Use this for initialization
	void Start () {
		// Loading Level
		
		// 
		UpdateBorder ();


		GameObject land = GameObject.Find ("Land1");
		//land.transform.position.x = rightBorder;

		//transform.position.x = Mathf.Clamp(transform.position.x,leftBorder,rightBorder);

		//while(Voxels.Peek().transform.position.x)
			AddVoxelToStart (land);
	}

	// Creates and adds a voxel in front of the level
	// and moves the other prefabs by one
	void AddVoxelToStart(GameObject ground)
	{
		Voxels.Enqueue((GameObject)Instantiate(ground));
	}

	// Removes last Voxel
	void RemoveLastVoxel()
	{
		if (Voxels.Count > 0)
			Voxels.Dequeue ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	// Updates border, so there is no 
	void UpdateBorder() {
		float dist = (transform.position - Camera.main.transform.position).z;

		//leftBorder = Camera.main.ViewportToWorldPoint(Vector3(0,0,dist)).x;
		//rightBorder = Camera.main.ViewportToWorldPoint(Vector3(1,0,dist)).x;


	}
}
