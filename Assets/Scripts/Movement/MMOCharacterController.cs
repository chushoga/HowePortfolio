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
	//public float zoomSpeed = 2f;

	public float zoomMin = -2.0f;
	public float zoomMax = -10.0f;

	// Use this for initialization
	
	void Start () {
		
		zoom = -3.0f;

	}
	
	// Update is called once per frame
	void Update () {

		zoom += Input.GetAxis("Mouse ScrollWheel") * 50.0f;

		//Print("ZOOM: " + zoom);
		if(zoom > zoomMin) {
			zoom = zoomMin;
		}

		if(zoom < zoomMin) {
			zoom = zoomMax;
		}

		//camera.transform.position.z = zoom;

	}
}
