using UnityEngine;
using System.Collections;

public class MenuScene : MonoBehaviour {
	
	public Texture2D StartButton;
	public Texture2D QuitButton;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Draw menu
	void OnGUI()
	{
		// Make a background box
		GUI.Box(new Rect(10,10,100,130), "Game Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		StartButton = (Texture2D) Resources.Load("Menu/Texture/start-button", typeof(Texture2D));
		if(GUI.Button(new Rect(20,40,80,40), StartButton)) {
			Application.LoadLevel("GameScene");
		}
		
		// Make the second button.
		QuitButton = (Texture2D) Resources.Load("Menu/Texture/quit-button", typeof(Texture2D));
		if(GUI.Button(new Rect(20,90,80,40), QuitButton)) {
			Application.Quit();
		}
	}
}
