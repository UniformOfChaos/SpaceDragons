using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour 
{

	void  Start ()
	{

	}

	public int doorRaycast= 3;

	void  Update ()
	{
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		//Check for Collision
		if(Physics.Raycast(transform.position, fwd, doorRaycast))
		{
			//With a door
			if(hit.collider.gameObject.tag == "Door")
			{
				// Open the door
				hit.collider.gameObject.animation.Play("DoorOpen");
			}
		}
	}
}