using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

	Queue<GameObject> Voxels = new Queue<GameObject>(); 

	// Use this for initialization
	void Start () {
		// Loading Level

		// 
		var dist = (transform.position - Camera.main.transform.position).z;
		var leftBorder = Camera.main.ViewportToWorldPoint(Vector3(0,0,dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint(Vector3(1,0,dist)).x;
		
		transform.position.x = Mathf.Clamp(transform.position.x,leftBorder,rightBorder);

		while(Voxels.Peek().transform.position.x)
		AddVoxelToStart (GameObject.Find ("Land1"));
	}

	// Creates and adds a voxel in front of the level
	// and moves the other prefabs by one
	void AddVoxelToStart(GameObject ground)
	{
		/*Voxels.Enqueue(*/Instantiate(ground);//);
	}

	void RemoveLastVoxel()
	{
		if (Voxels.Count > 0)
			Voxels.Dequeue ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
