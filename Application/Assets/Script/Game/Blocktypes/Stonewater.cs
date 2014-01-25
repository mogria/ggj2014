using UnityEngine;
using System.Collections;

public class Stonewater : Voxel {
	public static GameObject originalObject;
	public GameObject normalObject;
	
	/// <summary>
	/// Initializes a new instance of the Wather class.
	/// </summary>
	public Stonewater(Vector3 position)
	{
		initialize ();
		
		normalObject = (GameObject)Instantiate(originalObject, position, Quaternion.Euler(270,90,0));
		normalObject.AddComponent ("Stonewater");
	}
	
	protected static void initialize()
	{
		if(originalObject == null)
			originalObject = init ("Steinwasser1");
	}
	
	/// <summary>
	/// Gets the original GameObject.
	/// </summary>
	/// <returns>The original.</returns>
	public static GameObject getOriginal ()
	{
		initialize ();
		
		return originalObject;
	}
	
	/// <summary>s
	/// Update this instance.
	/// </summary>
	public override void Update ()
	{
		
	}
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	public override void Start ()
	{
		
	}
}
