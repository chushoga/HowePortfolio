using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelController : MonoBehaviour
{

	public float rotSpeed = 0.0f; // rotation speed for the character

	// ANIMATIONS
	public List<GameObject> gm;
	private Animator anim;

	// UI
	public RectTransform parentPanel;
	public GameObject actionButtonPrefab;
	private GameObject actionPanel;

	void Start()
	{
		
		GameObject model = Instantiate(gm[1], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		model.transform.SetParent(gameObject.transform, false);

		// Find the action panel
		actionPanel = GameObject.Find("ActionPanel");

		// Check if the action actually exists
		if(actionPanel != null) {

			anim = gm[1].GetComponent<Animator>();

			Debug.Log(parentPanel.childCount);
			Debug.Log(anim.runtimeAnimatorController.animationClips.Length);
			//anim.SetBool("isWalking", false);

			int i = 0;
			foreach(AnimationClip ac in anim.runtimeAnimatorController.animationClips){

				string animationName = anim.runtimeAnimatorController.animationClips[i].name;

				//anim.runtimeAnimatorController.animationClips
				Debug.Log(anim.runtimeAnimatorController.animationClips[i].name.GetType());

				GameObject a = (GameObject)Instantiate(actionButtonPrefab);
				a.transform.SetParent(actionPanel.transform, false);

				Text txt = a.GetComponentInChildren<Text>();

				txt.text = anim.runtimeAnimatorController.animationClips[i].name;

				a.GetComponent<Button>().onClick.AddListener(() => PlayAnimationButton(animationName));

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


	// Play the animation
	void PlayAnimationButton(string animName){
		anim.Play(animName);
	}

	// Start he model rotation
	public void StartRotating(){
		rotSpeed = 20.0f;
	}

	// Stop the model rotation
	public void StopRotating(){
		rotSpeed = 0;
	}

}
