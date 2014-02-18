using UnityEngine;
using System.Collections;

public class ControlsScene : MonoBehaviour 
{
	[ExecuteInEditMode]

	public GUITexture controlsImage;

	GUISkin gSkin;
	Texture2D backdrop;

	void Awake()
	{
		controlsImage = GameObject.Find("Controls").guiTexture;
	}

	void  Start ()
	{
		controlsImage.enabled = true;
	}

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
	
		if(GUI.Button( new Rect((Screen.width/2)+100,Screen.height - 80, 140, 70), "Close"))
		{
			Application.LoadLevel("MainMenu");
		}
	}
}