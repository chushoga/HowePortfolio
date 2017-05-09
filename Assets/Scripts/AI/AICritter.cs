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
	[SerializeField] float turnSpeed = 200f;


	Rigidbody rb;

	// Use this for initialization
	void Start () {
		// get Rigidbody
		rb = GetComponent<Rigidbody>();

		//lock rotaiton
		rb.constraints = RigidbodyConstraints.FreezeRotation;


		collisionBarrier = GetComponent<SphereCollider>(); // grab the sphere collider
		startPos = this.transform.position; 

		// set target pos for TESTING
		targetPos = RandomDirection();
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * wanderSpeed);

		// TODO: have the gameobject move forward towards they way they are facing.
		if(Input.GetKey(KeyCode.W)) {
			transform.position += transform.forward * Time.deltaTime * wanderSpeed;
		}
		else if(Input.GetKey(KeyCode.S)) {
			rb.position -= transform.forward * Time.deltaTime * wanderSpeed;
		}

		if(Input.GetKey(KeyCode.D)) {
			transform.Rotate(0, Time.deltaTime * turnSpeed, 0);
		}
		else if(Input.GetKey(KeyCode.A)) {
			transform.Rotate(0, Time.deltaTime * -turnSpeed, 0);
		}
	}

	// pick a random direction and go
	Vector3 RandomDirection(){
		
		Vector3 position = new Vector3(Random.Range(-wanderRange, wanderRange), 0, Random.Range(-wanderRange, wanderRange));

		return position;

	}
}
