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
	public override void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		
	}

	public override string getPrefabPath() {
		return null;
	}
	
	public override GameObject getOriginal()
	{
		return null;
	}
}
