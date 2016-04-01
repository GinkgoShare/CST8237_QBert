using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	private GameObject sheep;

	void Start() {
		sheep = GameObject.FindGameObjectWithTag ("Sheep");
	}

	public void ChangeSceneWithName(string sceneName) {
		// Load the specified Scene
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
	}
}
