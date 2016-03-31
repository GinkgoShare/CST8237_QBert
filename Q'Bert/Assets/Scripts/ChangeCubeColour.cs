using UnityEngine;
using System.Collections;

public class ChangeCubeColour : MonoBehaviour {

	//public Material materialToChange;

	private bool _hasChangedColor = false;

	private static bool _canChangeColour = false;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Sheep") && !_hasChangedColor) {
			if (_canChangeColour) {
				_hasChangedColor = true;
				this.GetComponent<MeshRenderer> ().material.color = new Color (0.0f, 0.0f, 1.0f);
			} else {
				_canChangeColour = true;
			}
		}
	}
}
