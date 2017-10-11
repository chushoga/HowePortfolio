using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour {

	public void changeMenuScene(string sceneName) {
		SceneManager.LoadScene (sceneName);

	}

}
