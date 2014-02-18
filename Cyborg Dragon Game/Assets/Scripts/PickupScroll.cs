using UnityEngine;
using System.Collections;

public class PickupScroll : MonoBehaviour 
{

	GUIText pickupScrollText;
	GameObject other;

	void  Start ()
	{
		pickupScrollText.enabled = false;
		pickupScrollText = GameObject.Find("pickupScrollText").guiText;
	}

	void  Update ()
	{

	}

	void OnControllerColliderHit ( ControllerColliderHit hit  )
	{
		other = hit.collider.gameObject;
	
		if(other.tag == "Scroll")
		{
			Destroy(other);
			DisplayPickupScrollText();
		}
	}

	void DisplayPickupScrollText()
	{
		StartCoroutine(PSTextEnum());
	}

	IEnumerator PSTextEnum()
	{
		pickupScrollText.enabled = true;
		yield return new WaitForSeconds(4);
		pickupScrollText.enabled = false;
	}
}