using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMOCharacterController : MonoBehaviour {

	//public Transform character, centerPoint;

	public GameObject camera;

	//private float mouseX, mouseY;
	//public float mouseSensativity = 10.0f;

	//private float moveFB, moveLR;
	//public float moveSpeed = 2f;

	public float zoom;
	public float zoomSpeed = 100f;

	public float zoomMin = -2.0f;
	public float zoomMax = -10.0f;

	Vector3 pos;


	void Start () {
		
		zoom = -10.0f;
		camera.transform.position = new Vector3(transform.position.x,transform.position.y,zoom);

		pos = camera.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetAxis("Mouse ScrollWheel") != 0){
			
		}

		if(Input.GetAxis("Mouse ScrollWheel") > 0){
			pos.z += 1f;
			camera.transform.position = pos;
		}

		if(Input.GetAxis("Mouse ScrollWheel") < 0){
			pos.z -= 1f;
			camera.transform.position = pos;
		}

		if(pos.z > zoomMin) {
			camera.transform.position = zoomMin;
		}

		if(pos.z < zoomMax) {
			camera.transform.position = zoomMax;
		}

	}
}
