using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// requires a sphere collider for the collision detection.
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class AICritter : MonoBehaviour {

	Vector3 startPos; // starting position
	Vector3 targetPos; // target position

	SphereCollider collisionBarrier;

	[SerializeField] float wanderRange = 10f;
	[SerializeField] float wanderSpeed = 2.5f;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		// get Rigidbody
		rb = GetComponent<Rigidbody>();

		//lock rotaiton
		rb.constraints = RigidbodyConstraints.FreezeRotation;


		collisionBarrier = GetComponent<SphereCollider>(); // grab the sphere collider
		startPos = this.transform.position; 
		Debug.Log(startPos);
	}
	
	// Update is called once per frame
	void Update () {
		float step = wanderSpeed * Time.deltaTime;
		//transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
	}
}
