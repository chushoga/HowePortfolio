using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	private Rigidbody rb;
	private float moveSpeed = 0.70f;
	private float rotSpeed = 50.0f;
	private float jumpHeight;
	private Animator ani;
	private bool isGrounded;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		ani = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {		
		// MOVE ***********************
		if (Input.GetKey(KeyCode.Q)) {
			transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
			ani.SetBool ("isWalking", true);
		}
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
			ani.SetBool ("isWalking", true);
		}
		if (Input.GetKey(KeyCode.S)) {
			transform.Translate (Vector3.back * moveSpeed * Time.deltaTime);
			ani.SetBool ("isWalking", true);
		}
		if (Input.GetKey (KeyCode.E)) {
			transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
			ani.SetBool ("isWalking", true);
		}
		// ROTATE ***********************
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up * rotSpeed * Time.deltaTime);
			ani.SetBool ("isWalking", true);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (-Vector3.up * rotSpeed * Time.deltaTime);
			ani.SetBool ("isWalking", true);
		}
		// JUMP ***********************
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true) {
			rb.AddForce (0f, 5.0f, 0f, ForceMode.Impulse);
			ani.SetBool ("isWalking", true);
			isGrounded = false;
		}
		// IDLE ***********************
		if(!Input.anyKey){
			ani.SetBool ("isWalking", false);
		}
	}

	// Change isGrounded to true after collision.
	void OnCollisionEnter(Collision collision){
		isGrounded = true;
	}

}
