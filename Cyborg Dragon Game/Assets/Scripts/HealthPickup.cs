using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour 
{

	void  OnCollisionEnter ( Collision collision  )
	{
		Debug.Log("Player collided");
		GameObject other= collision.collider.gameObject;
	
		if(other.tag == "Player")
		{
			// If player collides with potion, destroy potion instance
			Destroy(this.gameObject);
		}
	}

	void  OnTriggerEnter ( Collider other  )
	{
		Debug.Log("Player collided");
	}
}