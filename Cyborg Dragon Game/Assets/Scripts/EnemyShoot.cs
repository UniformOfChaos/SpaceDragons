using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour 
{
	Transform enemyProjectile;
	public int reloadTime= 1;
	float creationTime;
	public float shootProjectile;

	void  Awake ()
	{
		creationTime = Time.time;
	}

	void  Update ()
	{
		/*if(EnemyScript.attackPlayer)
		{
			startAttack();
		}*/
	}

	void  startAttack ()
	{
		if (Time.time > creationTime + reloadTime)
		{
		//	shootProjectile= Instantiate(enemyProjectile, transform.position, transform.rotation);
		//	shootProjectile.rigidbody.AddForce(transform.forward*1000);
			creationTime = Time.time;
		}
	}
}