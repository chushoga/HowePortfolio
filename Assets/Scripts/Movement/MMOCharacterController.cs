using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMOCharacterController : MonoBehaviour {

	public Transform target;

	float zoomMin = 1.0f;
	float zoomMax = 5.0f;
	float zoomOffset = 4.5f;

	Vector3 cameraRotation;

	void Start () {

		// Get camera rotation
		cameraRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
		Debug.Log (cameraRotation);
		
		// start zoom at half of the max
		Camera.main.orthographicSize = zoomMax / 2.0f;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z - zoomOffset);
		transform.eulerAngles = cameraRotation;
		
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
