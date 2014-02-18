using UnityEngine;
using System.Collections;

public class EnterRuin : MonoBehaviour 
{
	void OnTriggerEnter()
	{
		print ("Entered the ruin...");
		// For now, no other levels hve been done, so just load the Game Over screen 
		Application.LoadLevel("GameOver");
	}
}