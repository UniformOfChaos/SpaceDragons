using UnityEngine;
using System.Collections;
using RuinsOfEldrua;

public class HealthAndManaText : MonoBehaviour 
{
	GUIText healthText;
	GUIText manaText;

	HealthSystem health;
	ManaSystem mana;

	public string healthStr= "";

	void Awake()
	{
		healthText = GameObject.Find("CurrentHealthText").guiText;	
		manaText = GameObject.Find("CurrentManaText").guiText;

		// Seems GetComponent doesn't exist in C#... what.
		//health = GameObject.FindWithTag("Player").GetComponent<"HealthSystem">;
		//mana = GameObject.FindWithTag("Player").GetComponent<"ManaSystem">;
	}
	
	void  Update()
	{
		healthStr = Mathf.FloorToInt(health.currentHealth).ToString();
		healthText.text = healthStr;
		manaText.text = mana.ToString();
	}
}