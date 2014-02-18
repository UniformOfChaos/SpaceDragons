using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour 
{

	public float creationTime = Time.time;
	public int lifeTime = 3;
	private GameObject other;

	void  Awake ()
	{
		creationTime = Time.time;
	}

	void  OnCollisionEnter ( Collision collision  )
	{
		other = collision.collider.gameObject;
	
		if(other.tag == "Player")
		{
			// If player collides with projectile, destroy projectile instance
			Destroy(gameObject);
		}
	}

	void  Update (){
		if(Time.time > (creationTime + lifeTime))
		{
			Destroy(gameObject);
		}
	}
}