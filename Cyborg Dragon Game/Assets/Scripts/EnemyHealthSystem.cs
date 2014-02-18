using UnityEngine;
using System.Collections;

public class EnemyHealthScript : MonoBehaviour 
{

	public float maxEnemyHealth= 50.0f;
	public float enemyCurrentHealth= 50.0f;

	void  Update ()
	{
		// Enemy is dead
		if (enemyCurrentHealth <= 0.0f)
		{
			Destroy(gameObject);
		}
	}

	void  OnCollisionEnter ( Collision hit  )
	{
		Debug.Log(hit.gameObject.name + "was hit");
		
		// NOTE: Change this to a case statement, it'd be cleaner
		if(hit.collider.gameObject.tag == "Fireball")
		{
			enemyCurrentHealth -= 25;
			print("Ouch, hot!");
		}
		else
		{
			if(hit.collider.gameObject.tag == "Sword")
			{
				Debug.Log("SwordHit");
				enemyCurrentHealth -= 25;
				print("Ouch, sharp!");
			}
			else
			{
				if(hit.collider.gameObject.tag == "CrossbowBolt")
				{
					enemyCurrentHealth -= 15;
					print("Ouch, pointy!");
				}
			}
		}
	}
}