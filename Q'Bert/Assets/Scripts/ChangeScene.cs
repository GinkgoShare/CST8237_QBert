using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	public void ChangeSceneWithName(string sceneName) {
		// Load the specified Scene
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
	}
}
