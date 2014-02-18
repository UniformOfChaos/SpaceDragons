using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour 
{
	[ExecuteInEditMode]

	static GUISkin gSkin;
	Texture2D backdrop;

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
	
		if(GUI.Button( new Rect((Screen.width/2)-60,Screen.height -250, 140, 70), "Continue"))
		{
			Application.LoadLevel("MainMenu");
		} 
	}
}