using UnityEngine;
using System.Collections;

public class BoundaryTrigger : MonoBehaviour {

	public AudioSource splatSound;

	void OnTriggerExit(Collider other) {
		splatSound.Play ();
	}
}
