using UnityEngine;
using System.Collections;

public class DiaryPickup : MonoBehaviour 
{

	GUITexture diaryImage1;
	GUITexture diaryImage2;
	GUITexture diaryImage3;

	GUIText closeDiaryText;

	GameObject other;

	void Awake()
	{
		diaryImage1 = GameObject.Find("DiaryImage1").guiTexture;
		diaryImage2 = GameObject.Find("DiaryImage2").guiTexture;
		diaryImage3 = GameObject.Find("DiaryImage3").guiTexture;
		closeDiaryText = GameObject.Find("CloseDiaryText").guiText;
	}
	
	void  Start ()
	{
		// Hide all pages
		diaryImage1.enabled = false;
		diaryImage2.enabled = false;
		diaryImage3.enabled = false;
	
		closeDiaryText.enabled = false;
	}

	void  LateUpdate ()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			// Hide all pages
			diaryImage1.enabled = false;
			diaryImage2.enabled = false;
			diaryImage3.enabled = false;
			
			closeDiaryText.enabled = false;
		}	
	}

	// Pickup Diary Pages

	void  OnControllerColliderHit ( ControllerColliderHit hit  )
	{
		other = hit.collider.gameObject;
		
		if(other.tag == "DiaryPage")
		{
			Destroy(other);
			if (other.name == "DiaryPage1")
			{
				// Show first diary page
				diaryImage1.enabled = true;
				diaryImage2.enabled = false;
				diaryImage3.enabled = false;
			
				// Show prompt to close diary
				closeDiaryText.enabled = true;
			
			}
			else
			{
				if (other.name == "DiaryPage2")
				{
					// Show second diary page
					diaryImage1.enabled = false;
					diaryImage2.enabled = true;
					diaryImage3.enabled = false;
				
					// Show prompt to close diary
					closeDiaryText.enabled = true;
				}
				else
				{
					if (other.name == "DiaryPage3")
					{
						// Show third diary page
						diaryImage3.enabled = true;
						diaryImage1.enabled = false;
						diaryImage2.enabled = false;
					
						// Show prompt to close diary
						closeDiaryText.enabled = true;
					}
				}
			}
		}
	}
}