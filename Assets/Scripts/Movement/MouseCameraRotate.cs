using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraRotate : MonoBehaviour {

	public Transform target;
	public float angularSpeed;

	[SerializeField][HideInInspector]
	private Vector3 initalOffset;

	private Vector3 currentOffset;

	[ContextMenu("Set Current Offset")]
	private void SetCurrentOffset(){

		if (target == null){
			return;
		}

		initalOffset = transform.position - target.position;
	}


	// Use this for initialization
	void Start () {
		if(target == null){
			Debug.LogError("Assign a target for the camera! N.");
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = target.position + currentOffset; 

		float movement = Input.GetAxis("Horizontal") * angularSpeed * Time.deltaTime;

		if(!Mathf.Approximately(movement, 0f)){
			transform.RotateAround(target.position, Vector3.up, movement);
			currentOffset = transform.position - target.position;
		}
	}
}
