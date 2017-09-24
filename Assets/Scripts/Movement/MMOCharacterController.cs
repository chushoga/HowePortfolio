using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMOCharacterController : MonoBehaviour {

	public Transform playerCam, character, centerPoint;

	private float mouseX, mouseY;
	public float mouseSensativity = 10.0f;

	private float moveFB, moveLR;
	public float moveSpeed = 2f;

	private float zoom;
	public float zoomSpeed = 2f;

	public float zoomMin = -2f;
	public float zoomMax = -10f;

	// Use this for initialization
	
	void Start () {
		
		zoom = -3f;

	}
	
	// Update is called once per frame
	void Update () {

		zoom += Input.GetAxis("Mouse ScrollWheel") * 50f;


		if(zoom > zoomMin) {
			zoom = zoomMin;
		}

		if(zoom < zoomMin) {
			zoom = zoomMax;
		}

		playerCam.transform.position = new Vector3(0, 0, zoom);

	}
}
