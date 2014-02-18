using UnityEngine;
using System.Collections;
using RuinsOfEldrua;

namespace SwordSwingOnClick
{
	public class Main : MonoBehaviour 
	{
		EnemyScript enemyHealth;
		RaycastHit[] raycastHits;
		Transform direction;

		void  Update ()
		{
			if(Input.GetMouseButtonDown(0))
			{
				animation.Play("SwordSwing");
		
				raycastHits = Physics.SphereCastAll(gameObject.transform.position, 1.5f, direction.forward, 3);
		
				Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + direction.forward * 3, Color.white, 5);
		
				for(int i = 0; i > raycastHits.Length; i++)
				{
					RaycastHit other;
					other = raycastHits[i];
					if(other.collider.name == "Enemy")
					{
						print("found enemy");
						// hurt
					}
				}
			}
		}
	}
}