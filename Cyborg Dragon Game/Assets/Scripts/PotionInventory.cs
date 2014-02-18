using UnityEngine;
using System.Collections;
using RuinsOfEldrua;

public class PotionInventory : MonoBehaviour 
{
	
	public int HealthPotionsCollected;
	public int ManaPotionsCollected;

	GUIText HPText;
	GUIText MPText;

	public string HealthPotStr= "";
	public string ManaPotStr= "";

	GUIText HealthPickupText;
	GUIText ManaPickupText;

	HealthSystem health;
	ManaSystem mana;

	void  Awake ()
	{
		HealthPotionsCollected = 0;
		ManaPotionsCollected = 0;
		HealthPotStr = "";
		ManaPotStr = "";
		HealthPickupText.enabled = false;
		ManaPickupText.enabled = false;

		HealthPickupText = GameObject.Find("HealthPotionPickupText").guiText;
		ManaPickupText = GameObject.Find("ManaPotionPickupText").guiText;
		
		health = GameObject.FindWithTag("Player").GetComponent<HealthSystem>();
		mana = GameObject.FindWithTag("Player").GetComponent<ManaSystem>();
	}

	IEnumerator HealthTextEnum()
	{
		HealthPickupText.enabled = true;
		yield return new WaitForSeconds(4);
		HealthPickupText.enabled = false;
	}

	void DisplayHealthText()
	{
		StartCoroutine(HealthTextEnum());
	}

	void OnControllerColliderHit ( ControllerColliderHit hit  )
	{
		GameObject other= hit.collider.gameObject;
		if(other.tag == "HealthPotion") // If player hits a health potion
		{
			other.tag = "Untagged";
			Debug.Log("Player collided");
			Destroy(other);
		
			// Increment Health potions
			HealthPotionsCollected += 1;
			HealthPotStr = HealthPotionsCollected.ToString();
			HPText.text = HealthPotStr;
			DisplayHealthText();
		}
	
		if(other.tag == "ManaPotion") // If player hits a mana potion
		{
			other.tag = "Untagged";
			Debug.Log("Player collided");
			Destroy(other);
		
			// Increment Mana potions
			ManaPotionsCollected += 1;
			ManaPotStr = ManaPotionsCollected.ToString();
			MPText.text = ManaPotStr;
			DisplayManaPickupText();
		}
	}

	void DisplayManaPickupText()
	{
		StartCoroutine(ManaPickupEnum());
	}

	IEnumerator ManaPickupEnum()
	{
		ManaPickupText.enabled = true;
		yield return new WaitForSeconds(4);
		ManaPickupText.enabled = false;
	}

	void  Update ()
	{
		// When player presses the button to use a potion
		if(Input.GetKeyDown ("h"))
    	{	
    		// if player has potions to use
    		if(HealthPotionsCollected != 0)
    	{
    	   	// Increase health
    	   	health.currentHealth += 50;
    	  	if(health.currentHealth > health.maxHealth)
    	  	{
    	  		health.currentHealth = health.maxHealth;
    	  	}
    	   	
    		// Decrease number of health potions held
    		HealthPotionsCollected -= 1;
    		HealthPotStr = HealthPotionsCollected.ToString();
			HPText.text = HealthPotStr;	
    	}
    	else
    	{
    		Debug.Log("Out of Health Potions!");
    	}
    }
    
    if(Input.GetKeyDown("m"))
    {
    	// if player has potions to use
    	if(ManaPotionsCollected != 0)
    	{
    		// Increase Mana
    		mana.currentMana += 50;
    		if(mana.currentMana > mana.maxMana)
    	  	{
    	  		mana.currentMana = mana.maxMana;
    	  	}
    		
    		// Decrease number of Mana Potions held
    		ManaPotionsCollected -= 1;
    		ManaPotStr = ManaPotionsCollected.ToString();
			MPText.text = ManaPotStr;
    	}
    	else
    	{
    		Debug.Log("Out of Mana Potions!");
    	}
    }
}
}