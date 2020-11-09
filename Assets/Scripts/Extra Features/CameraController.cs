using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.01f;        // The rate of change of the orthographic size in orthographic mode.

	private Camera cam;

	void Start(){
		cam= Camera.main;  
	}

	void Update()
	{
		int Speed = 5;

		//PC Controls....................
	
		//Zoom Out on pc
		if (Input.GetAxis("Mouse ScrollWheel") < 0 )
		{
			if (cam.orthographicSize<=5f)
				cam.orthographicSize +=0.5f;

		}
		// Zoom In on pc
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{

			if (cam.orthographicSize>=1)
				cam.orthographicSize -=0.5f;
		}

		float xAxisValue = Input.GetAxis("Horizontal") * Speed;
		float zAxisValue = Input.GetAxis("Vertical") * Speed;

		if (xAxisValue > 0) {
			cam.transform.position += cam.transform.right;

		}
		if (xAxisValue < 0) {
			cam.transform.position -= cam.transform.right;

		}
		if (zAxisValue > 0) {
			cam.transform.position += cam.transform.up;

		}
		if (zAxisValue < 0) {
			cam.transform.position -= cam.transform.up;

		}
			
		///////Mobile controls....


		if (Input.touchCount > 0 && Input.touchCount != 2 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			float speed = 0.005f;

			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			cam.transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);

			/*
			Touch touchSingle = Input.GetTouch (0);

			Vector2 touchSinglePrevPos = touchSingle.position - touchSingle.deltaPosition;

			float deltaMagnitudeDiff = touchSinglePrevPos.magnitude;

			if (cam.orthographic && deltaMagnitudeDiff<0) {
				//cam.transform.position -= new Vector3 (touchSinglePrevPos.x, touchSinglePrevPos.y ,0.0f); 
				cam.transform.position += cam.transform.right;
			}
			if (cam.orthographic && deltaMagnitudeDiff>0) {
				//cam.transform.position -= new Vector3 (touchSinglePrevPos.x, touchSinglePrevPos.y ,0.0f); 
				cam.transform.position -= cam.transform.right;
			}*/
		}

		// If there are two touches on the device...
		if (Input.touchCount == 2)
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			// If the camera is orthographic...
			if (cam.orthographic && cam.orthographicSize <5f)
			{
				// ... change the orthographic size based on the change in distance between the touches.
				cam.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

				// Make sure the orthographic size never drops below zero.
				cam.orthographicSize = Mathf.Max(cam.orthographicSize, 0.1f);
			}
			else
			{
				// Otherwise change the field of view based on the change in distance between the touches.
				cam.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

				// Clamp the field of view to make sure it's between 0 and 180.
				cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 0.1f, 179.9f);
			}
		}
	}

}
