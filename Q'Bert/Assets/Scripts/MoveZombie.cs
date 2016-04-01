using UnityEngine;
using System.Collections;

public class MoveZombie : MonoBehaviour {

	public float speed = 1.0f;

	public Animation animation;
	public AudioSource jumpSound;
	public AudioSource splatSound;

	private bool _canMove = true;

	void Start() {
		animation.playAutomatically = true;
		this.gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Top Panel")) {
			int coinFlip = (int)Random.Range (1, 3);
			jumpSound.Play ();
			animation.Play ();
			if (1 == coinFlip) {
				this.transform.rotation = Quaternion.Euler (0.0f, 225.0f, 0.0f);
				this.transform.Translate (new Vector3 (0.0f, 1.0f, 1.0f));
				ApplyDownwardForce ();
			} else {
				this.transform.rotation = Quaternion.Euler (0.0f, 135.0f, 0.0f);
				this.transform.Translate (new Vector3 (0.0f, 1.0f, 1.0f));
				ApplyDownwardForce ();
			}
		}
	}

	void ApplyDownwardForce() {
		this.GetComponent<Rigidbody>().AddForce (Vector3.up * 100);
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Boundary")) {
			Destroy (this.gameObject);
		}
	}
}
