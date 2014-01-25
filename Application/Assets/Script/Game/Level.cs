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

		// TMP Land1 fix
		GameObject land = GameObject.Find ("Land1");
		

		UpdateBorder();

		for (int i = (int)((rightBorder - leftBorder) / land.collider.bounds.size.x) + 2; i > 0; i--) {
			AddVoxelToStart (land, new Vector3(
				land.transform.position.x - (land.collider.bounds.size.x * i),
				land.transform.position.y,
				land.transform.position.z));
		}
	}

	GameObject AddVoxelToStart(GameObject ground)
	{
		return AddVoxelToStart(ground, new Vector3(0,0,0));
	}

	// Creates and adds a voxel in front of the level and returns the Gameobject
	GameObject AddVoxelToStart(GameObject ground, Vector3 position)
	{
		Voxels.Enqueue((GameObject)Instantiate(ground, position, Quaternion.Euler(270,90,0)));

		return ground;
	}

	// Removes last Voxel
	void RemoveLastVoxel()
	{
		if (Voxels.Count > 0)
			Voxels.Dequeue();
	}

	// Update is called once per frame
	void Update () {

		// no calculation of the screen size jet
		//UpdateBorder ();


	}

	// Updates border, so there is no 
	void UpdateBorder() {
		float dist = (GameObject.Find ("Land1").transform.position - Camera.main.transform.position).z;

		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,dist)).x;

		
		// TMP Land1 fix
		GameObject.Find ("Land1").transform.position = new Vector3(rightBorder + 1,
                           GameObject.Find ("Land1").transform.position.y,
                           GameObject.Find ("Land1").transform.position.z);
	}
}
