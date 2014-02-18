using UnityEngine;
using System.Collections;

public class ManaPickup : MonoBehaviour 
{
	void  OnCollisionEnter ( Collision collision  )
	{
		GameObject other= collision.collider.gameObject;
		if(other.tag == "Player")
		{
			// If player collides with potion, destroy potion instance
			Destroy(this.gameObject);
		}
	}
}