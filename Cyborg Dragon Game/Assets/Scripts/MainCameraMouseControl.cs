// MainCameraMouseControl.cs
// Written originally as part of last year's Introduction to Computer Gaming module; recycled and rewritten for this project.

using UnityEngine;
using System.Collections;

public class MainCameraMouseControl: MonoBehaviour
{
//	PRIMARY CONTROL SCRIPT; deals with mouse input and
//	activates OnClick functions of scripts in the   
//	'Interactive' layer. Make sure that all interactive
//	objects exist on this layer!
	
	// --- PUBLIC VARIABLES -----------------------------------------------------------------------
	
	public int bufferWidth;
	public int scrollSpeedDefault;
	public int zoomMax;
	public int zoomMin;
	public float rotationSpeedModifier;
	static private float cameraHeight;
	private float mainCameraXRotation = 30;
	private float mainCameraYRotation = 0;
	private Vector3 moveCoords;
	private string mouseControlMode = "";
	
	void Awake()
	{
		cameraHeight = Camera.mainCamera.transform.position.y;
	}
		
	void Update()
	{
		OnClickController();
		CameraMovementCheck();
	}
	
		// --- OnClick AND MouseOver CONTROLLERS ---------------------------------------------------
	
	void OnClickController ()
	{
	Ray mouseClickRay;
	RaycastHit clickedInfo;
	GameObject moveTarget;
	int groundLayer = 1<<LayerMask.NameToLayer("Ground");
		mouseClickRay = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
		if(Input.GetMouseButtonDown(0))
		{
			mouseClickRay = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(mouseClickRay, out clickedInfo, 450) == true)
			{
				moveCoords = clickedInfo.point;
				Debug.Log("Movement command given. moveCoords set to "  + moveCoords);
				moveTarget = GameObject.Find("MoveTarget");
				moveTarget.transform.position = moveCoords;
			}
		}
	}

// --- CAMERA MOVEMENT ---------------------------------------------------------------------
		
	void CameraMovementCheck ()
	{
	int scrollSpeed = scrollSpeedDefault;
	Event scrollingEvent = Event.current;
		if (Input.GetKey(KeyCode.LeftShift))
			scrollSpeed = scrollSpeedDefault*3;
		else
			scrollSpeed = scrollSpeedDefault;
		if (Input.GetMouseButton(1) == true)
		{
			mainCameraYRotation = mainCameraYRotation + (Input.GetAxis("Mouse X") * rotationSpeedModifier);
			mainCameraXRotation = mainCameraXRotation + (Input.GetAxis("Mouse Y") * rotationSpeedModifier);
		}
		else
		{
			//Left movement
			if (Input.mousePosition.x < bufferWidth || Input.GetKey(KeyCode.LeftArrow))
				Camera.mainCamera.transform.position = Camera.mainCamera.transform.position + scrollSpeed*(-(Camera.mainCamera.transform.right)*Time.deltaTime);
			//Right movement
			if (Input.mousePosition.x > Screen.width - bufferWidth || Input.GetKey(KeyCode.RightArrow))
				Camera.mainCamera.transform.position = Camera.mainCamera.transform.position + scrollSpeed*(Camera.mainCamera.transform.right)*Time.deltaTime;
			//Reverse movement
			if (Input.mousePosition.y < bufferWidth || Input.GetKey(KeyCode.DownArrow))	
				Camera.mainCamera.transform.position = Camera.mainCamera.transform.position + scrollSpeed*(-(Camera.mainCamera.transform.forward)*Time.deltaTime);
			//Forward movement
			if (Input.mousePosition.y > Screen.height - bufferWidth || Input.GetKey(KeyCode.UpArrow))
				Camera.mainCamera.transform.position = Camera.mainCamera.transform.position + scrollSpeed*(Camera.mainCamera.transform.forward)*Time.deltaTime;
			//Camera Zoom
			if (scrollingEvent != null && scrollingEvent.isMouse)
			{
				Camera.mainCamera.fieldOfView = Camera.mainCamera.fieldOfView + scrollingEvent.delta.x;
				if (Camera.mainCamera.fieldOfView < zoomMin)
					Camera.mainCamera.fieldOfView = zoomMin;
				if (Camera.mainCamera.fieldOfView > zoomMax)
					Camera.mainCamera.fieldOfView = zoomMax;
			}
		}
	}

	void LateUpdate()
	{
		//Check camera height.
		if (Camera.mainCamera.transform.position.y != cameraHeight)
		{
			Camera.mainCamera.transform.position = new Vector3(Camera.mainCamera.transform.position.x, 15, Camera.mainCamera.transform.position.z);
		}
		//Set camera rotation.
		Camera.mainCamera.transform.rotation = Quaternion.Euler(mainCameraXRotation,mainCameraYRotation,0);	
	}
}
