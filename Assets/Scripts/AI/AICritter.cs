using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICritter : MonoBehaviour {

	[SerializeField] float wanderRange = 10f;
	[SerializeField] float wanderSpeed = 2.5f;

	public GameObject spawnPoint;

	private Vector3 currentPos;
	public Vector3 targetPos;

	GameObject gm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float step = wanderSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
	}
}
