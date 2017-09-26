using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMOCharacterController : MonoBehaviour {

	public Transform target;
	public Transform player;

	float zoomMin = 1.0f;
	float zoomMax = 4.5f;
	float zoomOffset = 4.5f;

	Vector3 cameraRotation;

	void Start () {
		
		// start zoom at half of the max
		Camera.main.orthographicSize = zoomMax / 2.0f;
	}
	
	// camera tracking
	void LateUpdate () {

		// Get camera rotation
		float y = -player.transform.eulerAngles.y;
		cameraRotation = new Vector3(0, y, 0);
		target.transform.localEulerAngles = cameraRotation;
		
		if(Input.GetAxis("Mouse ScrollWheel") < 0) {
			Camera.main.orthographicSize += 0.5f;
		} 

		if(Input.GetAxis("Mouse ScrollWheel") > 0) {
			Camera.main.orthographicSize -= 0.5f;
		}

		// lock max and min size
		if(Camera.main.orthographicSize < zoomMin) {
			Camera.main.orthographicSize = zoomMin;
		}

		if(Camera.main.orthographicSize > zoomMax) {
			Camera.main.orthographicSize = zoomMax;
		}


	}
}
