using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICritter : MonoBehaviour {

	Vector3 startPos;
	Vector3 targetPos;

	[SerializeField] float wanderRange = 10f;
	[SerializeField] float wanderSpeed = 2.5f;

	public GameObject spawnPoint;

	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
		Debug.Log(startPos);
	}
	
	// Update is called once per frame
	void Update () {
		float step = wanderSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
	}
}
