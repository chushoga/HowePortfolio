using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{

	public float rotSpeed = 2.0f; // rotation speed for the character

	// ANIMATIONS
	public GameObject gm;

	// UI
	public RectTransform parentPanel;
	public GameObject actionButtonPrefab;

	void Start()
	{

		Animator anim = gm.GetComponent<Animator>();

		Debug.Log(parentPanel.childCount);
		anim.SetBool("isWalking", true);
		for(int i = 0; i < 5; i++) {
			
		}
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);

	}
}
