using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelController : MonoBehaviour
{

	public float rotSpeed = 2.0f; // rotation speed for the character

	// ANIMATIONS
	public GameObject gm;

	// UI
	public RectTransform parentPanel;
	public GameObject actionButtonPrefab;
	private GameObject actionPanel;

	void Start()
	{
		// Find the action panel
		actionPanel = GameObject.Find("ActionPanel");

		// Check if the action actually exists
		if(actionPanel != null) {

			Animator anim = gm.GetComponent<Animator>();

			Debug.Log(parentPanel.childCount);
			Debug.Log(anim.runtimeAnimatorController.animationClips.Length);
			anim.SetBool("isWalking", false);

			int i = 0;
			foreach(AnimationClip ac in anim.runtimeAnimatorController.animationClips){
				//anim.runtimeAnimatorController.animationClips
				Debug.Log(anim.runtimeAnimatorController.animationClips[i].name);

				GameObject a = (GameObject)Instantiate(actionButtonPrefab);
				a.transform.SetParent(actionPanel.transform, false);

				Text txt = a.GetComponentInChildren<Text>();

				txt.text = anim.runtimeAnimatorController.animationClips[i].name;

				i++;
			}


		} else {
			Debug.Log("some error");
		}


	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);

	}
}
