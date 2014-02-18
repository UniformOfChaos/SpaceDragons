using UnityEngine;
using System.Collections;

public class PotionRotate : MonoBehaviour 
{
	void  Start ()
	{

	}

	void  Update ()
	{
		transform.Rotate(Vector3.up * Time.deltaTime * 90);
	}
}