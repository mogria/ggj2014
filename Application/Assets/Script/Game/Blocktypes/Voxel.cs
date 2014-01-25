using UnityEngine;
using System.Collections;

public class Voxel : MonoBehaviour {

	// Load Prefab
	protected GameObject init()
	{
		return (GameObject)Resources.Load (getPrefabPath ());
	}

	public float getXSize()
	{
		return getOriginal().collider.bounds.size.x;
	}

	// Use this for initialization
	public virtual void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}

	public virtual string getPrefabPath() {
		return null;
	}
	
	public virtual GameObject getOriginal()
	{
		return null;
	}
}
