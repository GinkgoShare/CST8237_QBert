using UnityEngine;
using System.Collections;

public class ChangeCubeColour : MonoBehaviour {

	//public Material materialToChange;

	void OnCollisionEnter(Collision collision) {
		// = new Color(0.0f, 0.0f, 1.0f);
		this.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 1.0f);
	}
}
