using UnityEngine;
using System.Collections;

public class ChangeCubeColour : MonoBehaviour {

	//public Material materialToChange;

	private static bool _canChangeColour = false;

	void OnCollisionEnter(Collision collision) {
		// = new Color(0.0f, 0.0f, 1.0f);
		if (_canChangeColour) this.GetComponent<MeshRenderer> ().material.color = new Color (0.0f, 0.0f, 1.0f);
		else _canChangeColour = true;
	}
}
