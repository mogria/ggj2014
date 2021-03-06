﻿using UnityEngine;
using System.Collections;

public class Voxel : MonoBehaviour {

	// Load Prefab
	protected static GameObject init(string PrefabPath)
	{
		GameObject originalObject = (GameObject)Resources.Load (PrefabPath);

		originalObject.renderer.enabled = false;
		originalObject.transform.position = new Vector3 (0.0f, -5.53f, -0.283f);
		originalObject.transform.rotation = Quaternion.Euler (270, 90, 0);

		return originalObject;
	}

	// Use this for initialization
	public virtual void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}
}
