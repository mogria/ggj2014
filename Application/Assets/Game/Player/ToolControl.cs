using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using AssemblyCSharp;

public class ToolControl : MonoBehaviour {

	List<Tool> tools = new List<Tool>();
	// Use this for initialization
	void Start () {
		var firstTool = new Laser ();
		firstTool.Show ();
		tools.Add(firstTool);
		tools.Add(new Drill());
		tools.Add(new Jetpack());
		tools.Add(new BuilderTool());
	}
	
	// Update is called once per frame
	void Update () {
		string[] toolControls = {"Tool1", "Tool2", "Tool3", "Tool4"};

		for (int i = 0; i < toolControls.Length; i++) { 
			if(Input.GetButton(toolControls[i])) ChangeTool(i);
		}
	}

	void ChangeTool(int index) {
		tools.ForEach((tool) => tool.Hide());
		tools [index].Show();
	}
}
