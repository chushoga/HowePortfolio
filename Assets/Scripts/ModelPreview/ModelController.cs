using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{

	public float rotSpeed = 2.0f; // rotation speed for the character

	// ANIMATIONS
	public RuntimeAnimatorController aniCont; // animation controller

	// UI
	public RectTransform parentPanel;
	public GameObject actionButtonPrefab;

	void Start()
	{
		
		Debug.Log(parentPanel.childCount);
		for(int i = 0; i < aniCont.animationClips.Length; i++) {
			//Debug.Log(aniCont.animationClips[i].name);
		}
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);

	}
}
