using UnityEngine;
using System.Collections;
using RuinsOfEldrua;

namespace RuinsOfEldrua
{
	public class EnemyScript : MonoBehaviour 
	{
		/*public Transform enemyTarget;
		public float reactionRange = 15.0f;
		public float rotateSpeed = 1.50f;
		public float speed;
		public bool attackPlayer= false;

		HealthSystem playerHealth;

		public int enemyMaxHealth;
		public int enemyCurrentHealth;

		void Awake ()
		{
			enemyMaxHealth = 50;
			enemyCurrentHealth = 50;

			if (enemyTarget == "")
			{
				enemyTarget = GameObject.FindWithTag("Player").transform;
			}
		}

		public float currentDistance;
		public float enemyLook;
		public float targetRotation;

		public float forward;
		public float targetDirection;
		public float hitAngle;

		void  Update ()
		{
			// Find distance to player
			currentDistance= Vector3.Distance(transform.position,enemyTarget.position);
			//print("Distance to player is " + currentDistance);
	
			// Check if player is the tag, and player is within range.
			if(enemyTarget && withinRange())
			{
				// Rotate to look at player
				enemyLook = enemyTarget.position - transform.position;
				enemyLook.y = 0;
				targetRotation= Quaternion.LookRotation(enemyLook, Vector3.up);	
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
		
				// If enemy is more than 5 metres away from the player
				if(currentDistance > 5)
				{
					// Move towards player i.e. forward relative to where the enemy is looking.
					transform.Translate(speed * Vector3.forward * Time.deltaTime);
					speed = 3.0f;
				}
			
				forward = transform.forward;
				targetDirection= enemyTarget.position - transform.position;
				hitAngle= Vector3.Angle(targetDirection,forward);
		
				// Check if player is within 10 degrees of the front of the enemy
				if (hitAngle < 10.0f)
				{
					// attack player is only true if player is within 20m + hit angle < 10.
					attackPlayer = true;
					hurtPlayer();
				}
				else
				{
					attackPlayer = false;
					// stop moving 5 metres away from player
					speed = 0;
				}

				// Hurt Player		
				/*public hurtPlayer()
				{
					playerHealth = enemyTarget.GetComponent<"HealthSystem">();
	
					if(playerHealth.currentHealth > 0)
				{
					playerHealth.currentHealth -= 10 * Time.deltaTime;
					return playerHealth;
				}	
			}

			withinRange ()
			{
				// Check if player is within range
				if(Vector3.Distance(transform.position, enemyTarget.position) > reactionRange)
				{
					return false;
				}	
	
				RaycastHit hit;
	
				Debug.DrawLine(transform.position, enemyTarget.position, Color.yellow, 5);
	
				if(Physics.Linecast(transform.position, enemyTarget.position, hit))
				{
					// If raycast hits something other than the player
					if(hit.collider.gameObject.tag != "Player")
					{
						print("Obstacle detected: "+hit.collider.gameObject.name);
						return false;
					}
					else // if raycast hits player
					{
						//print("Player seen!!");
					}
				}
				return true;
			}


			}
		}
		*/
	}
}