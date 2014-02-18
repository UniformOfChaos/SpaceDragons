using UnityEngine;
using System.Collections;

namespace RuinsOfEldrua
{
	public class ManaSystem : MonoBehaviour 
	{
		public float maxMana= 100.0f;
		public float currentMana= 100.0f;
		GUITexture manaGUI;
		private float manaGUIWidth= 0.0f;
		GUIText manaText;

		public float manaFraction;

		void  Awake ()
		{
			manaGUIWidth = manaGUI.pixelInset.width;
			manaText= GameObject.Find("CurrentManaText").guiText;
		}

		void  ApplyManaSpent ( float manaSpent  )
		{
			// No mana spent
			if (currentMana < 0.0f)
			{
				return;
			}
	
			// Apply mana spent
			currentMana -= manaSpent;
		}

		void  ManaRegen()
		{
			if(currentMana < maxMana)
			{
				// Regen mana per second
				currentMana += 1;		
			}
		}

		void  LateUpdate ()
		{
			// Update GUI every frame
			// We do this in late update to make sure spells have already executed
			UpdateGUI();

			// Starting after 3 seconds.
			// Mana regenerates 1 per second
		
			InvokeRepeating("ManaRegen", 3, 1);
		}

		void  UpdateGUI ()
		{
			// Update Mana GUI
			// The mana GUI is rendered unsing an overlay texture which is scaled down based on mana
			// First, Calculate fraction of how much mana we have left
			manaFraction= Mathf.Clamp01(currentMana/maxMana);
	
			// Next, adjust maximum pixel inset based on it
			// In C# this needs to be stored in a temporary variable
			// C# won't let you directly alter Vector 3 variables in calculations like this
			Rect pos = manaGUI.pixelInset;
			pos.xMax = pos.xMin + manaGUIWidth * manaFraction;
			manaGUI.pixelInset = pos;
	
			manaText.text = currentMana.ToString();
		}
	}
}