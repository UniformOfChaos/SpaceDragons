using UnityEngine;
using System.Collections;

public class DestroyFireball : MonoBehaviour 
{

	public float creationTime = Time.time;
	int lifeTime = 2;
	GameObject explosion;

	void  Awake ()
	{
		creationTime = Time.time;
	}

	void  Update ()
	{
		if(Time.time > (creationTime + lifeTime))
		{
			Destroy(gameObject);
		}
	}

	void  OnCollisionEnter ( Collision hit  )
	{
		Instantiate(explosion,transform.position,transform.rotation);
		Destroy(gameObject);
	}
}