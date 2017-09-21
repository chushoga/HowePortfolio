using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraFollow : MonoBehaviour {

	public GameObject camTarget;

	// Update is called once per frame
	void Update () {
		Vector3 pos = camTarget.transform.position;
		pos.y += 50.0f;
		transform.position = pos;
	}
}
