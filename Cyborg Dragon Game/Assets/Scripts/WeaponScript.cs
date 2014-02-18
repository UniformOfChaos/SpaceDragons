using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour 
{

	public bool SwordSelected = false;

	void  Start ()
	{

	}

	void  Awake ()
	{
		// Select the first (default) weapon, Crossbow
		SelectWeapon(0); 
	}

	void  Update ()
	{	
	//NOTE: Change these to a case statement
		if(Input.GetKeyDown("1"))
		{
			//Select Crossbow
			SelectWeapon(0);
			SwordSelected = false;
		}
		else if (Input.GetKeyDown("2"))
		{
			//Select Sword
			SelectWeapon(1);
			SwordSelected = true;
		}
		else if (Input.GetKeyDown("3"))
		{
			//Select Torch
			SelectWeapon(2);
			SwordSelected = false;
		}
	}

	void  SelectWeapon ( int index  )
	{
		for(int i=0; i<transform.childCount; i++)
		{
			// Activate the selected weapon
			if(i==index)
			{
				transform.GetChild(i).gameObject.SetActiveRecursively(true);
				// Deactivate all other weapons
			}
			else
			{
				transform.GetChild(i).gameObject.SetActiveRecursively(false);
			}
		}
	}
}