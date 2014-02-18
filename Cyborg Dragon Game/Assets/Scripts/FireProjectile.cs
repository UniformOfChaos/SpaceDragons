using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour 
{
	public float speed= 4.0f;
	Transform CrossbowBolt;
	
	void  Start ()
	{

	}

	void  FixedUpdate ()
	{
		//Check if 'fire' buton is pressed
		if(Input.GetButtonDown("Fire1"))
		{
			//Instantiate the projectile
			GameObject bolt = (GameObject)Instantiate(CrossbowBolt,transform.position,transform.rotation);
		
			//Add forces to the projectile
	 		bolt.rigidbody.AddForce(transform.forward * speed);
		}
	}

	void  OnTriggerEnter ( Collider hit  )
	{
		GameObject other= hit.collider.gameObject;
	
		if(other.tag == "Enemy" || other.tag == "Terrain")
		{
			//Damage Enemy
			print("Bolt hit enemy");
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}