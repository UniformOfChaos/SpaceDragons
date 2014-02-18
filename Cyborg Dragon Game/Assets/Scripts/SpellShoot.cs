using UnityEngine;
using System.Collections;
using RuinsOfEldrua;

public class SpellShoot : MonoBehaviour {


bool oom= false;
GUIText oomtext;
float speed= 700.0f;
Transform Fireball;
ManaSystem playerMana;

void  Start ()
{	
	oomtext = GameObject.Find("OOMText").guiText;
	oomtext.enabled = false;
}

void  Update ()
{
	playerMana = GameObject.FindWithTag("Player").GetComponent<ManaSystem>();
	
	//Check if 'spell fire' buton is pressed
	if(Input.GetButtonDown("Fire2"))
	{
		if (playerMana.currentMana >= 10)
		{
			//Instantiate the projectile
			GameObject fireball = (GameObject) Instantiate(Fireball,transform.position,transform.rotation);
		
			//Add forces to the projectile
		 	fireball.rigidbody.AddForce(transform.forward * speed);
	 	
	 		// Drain Mana
	 		playerMana.currentMana -= 10;
	 	}
	 	else
	 	{
	 		// Out of Mana
	 		oom = true;
	 		if (oom == true)
	 		{
	 			DisplayOOMText();
	 		}
	 	}
	 }
}

void DisplayOOMText()
{
		StartCoroutine(OutOfManaEnum());
}

IEnumerator OutOfManaEnum()
{
	print("Out of Mana!");
	oomtext.enabled = true;
	yield return new WaitForSeconds(3);
	oomtext.enabled = false;
}

}