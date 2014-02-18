using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour 
{

	// make the script execute in edit mode
	[ExecuteInEditMode]

	static GUISkin gSkin;

	Texture2D backdrop; // our backdrop image goes here

	void  OnGUI ()
	{
		if (gSkin)
		{
			GUI.skin = gSkin;
		}	
		else
		{
			Debug.Log("StartMenuGUI Skin object missing!");
		}
	
		GUIStyle backgroundStyle = new GUIStyle();
		backgroundStyle.normal.background = backdrop;
	
		// Title
		GUI.Label( new Rect((Screen.width/2)-150,80,300,200),"Ruins of Eldrua");
	
		//Play Button
		if(GUI.Button( new Rect((Screen.width/2)-70,Screen.height - 340, 140, 70), "Start"))
		{
			Application.LoadLevel("Island"); // Load the game level
		}
	
		// Story button
		if(GUI.Button( new Rect((Screen.width/2)-70,Screen.height - 260, 140, 70), "Story"))
		{
			// Show Story Image
			Application.LoadLevel("Story");
		}
	
		//Controls Button
		if(GUI.Button( new Rect((Screen.width/2)-70,Screen.height - 180, 140, 70), "Controls"))
		{
			Application.LoadLevel("Controls");
		} 
	
		//Quit Button
		if(GUI.Button( new Rect((Screen.width/2)-70,Screen.height - 100, 140, 70), "Quit"))
		{
			Application.Quit();
		}	
	}
}