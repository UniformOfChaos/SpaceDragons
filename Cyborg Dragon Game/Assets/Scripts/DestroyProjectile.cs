using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour 
{

	public float creationTime= Time.time;
	public int lifeTime= 2;

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
		Destroy(gameObject);
	}
}