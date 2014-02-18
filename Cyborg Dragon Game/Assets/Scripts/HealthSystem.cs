using UnityEngine;
using System.Collections;

namespace RuinsOfEldrua
{
	public class HealthSystem : MonoBehaviour 
	{
		public float maxHealth = 100.0f;
		public float currentHealth = 100.0f;

		static GUITexture healthGUI;
		public float healthGUIWidth = 0;

		public float healthFraction;

		void  Awake ()
		{

		}

		void  Update ()
		{
			// Player has taken too much damage and is now dead
			if (currentHealth < 0.0f)
			{
				Application.LoadLevel("GameOver");
			}
		}

		void  HealthRegen ()
		{
			if(currentHealth < maxHealth)
			{
				// Regen health per second
				currentHealth += 1;		
			}
		}

		void  LateUpdate ()
		{
			// Update GUI every frame
			// We do this in late update to make sure weapons etc. were already executed
			UpdateGUI();
			InvokeRepeating("HealthRegen", 3, 1);
		}


		void  UpdateGUI ()
		{
			// Update Health GUI
			// The health GUI is rendered unsing an overlay texture which is scaled down based on health
			// First, Calculate fraction of how much health we have left
			healthGUIWidth = healthGUI.pixelInset.width;
			healthFraction = Mathf.Clamp01(currentHealth/maxHealth);
	
			// Next, adjust maximum pixel inset based on it
			// In C# this needs to be stored in a temporary variable
			// C# won't let you directly alter Vector 3 variables in calculations like this
			Rect pos = healthGUI.pixelInset;
			pos.xMax = pos.xMin + healthGUIWidth * healthFraction;
			healthGUI.pixelInset = pos;
		}
	}
}