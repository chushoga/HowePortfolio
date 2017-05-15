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
	[SerializeField] float turnSpeed = 50f;

	public GameObject spawnTo;


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
		LookTowards(); // look at new direction
	}
	
	// Update is called once per frame
	void Update () {



		transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * wanderSpeed);


		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Debug.DrawRay(transform.position, targetPos, Color.green);

		if (Mathf.Round(transform.position.x) == Mathf.Round(targetPos.x) && Mathf.Round(transform.position.z) == Mathf.Round(targetPos.z)){
			Debug.Log("reached pos");
			targetPos = RandomDirection();
			LookTowards(); // look at new direction
		}

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

		Instantiate(spawnTo, position, Quaternion.identity);

		return position;

	}

	void LookTowards (){
		Vector3 targetDir = new Vector3(targetPos.x - transform.position.x, 0, targetPos.z - transform.position.z);
		float step = turnSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 20.0f*Time.deltaTime, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);

		Debug.Log(">>>>>>>>>>>>> currentRotation: "+transform.rotation);
		Debug.Log(">>>>>>>>>>>>> newDir: "+targetDir);
	}
}
