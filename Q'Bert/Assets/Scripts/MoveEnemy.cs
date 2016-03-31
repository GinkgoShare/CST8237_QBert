using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	public float speed = 1.0f;

	public AudioSource jumpSound;

	private bool _canMove = true;

//	void Update () {
//		int coinFlip = (int)Random.Range (1, 3);
//		if (1 == coinFlip) {
//			_canMove = false;
//			this.transform.rotation = Quaternion.Euler (0.0f, 225.0f, 0.0f);
//			this.transform.Translate (new Vector3 (0.0f, 0.4f, 1.0f));
//			ApplyDownwardForce ();
//		} else {
//			_canMove = false;
//			this.transform.rotation = Quaternion.Euler (0.0f, 135.0f, 0.0f);
//			this.transform.Translate (new Vector3 (0.0f, 0.4f, 1.0f));
//			ApplyDownwardForce ();
//		}
//	}

	void ApplyDownwardForce() {
		this.GetComponent<Rigidbody>().AddForce (Vector3.down * speed);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Top Panel")) {
			int coinFlip = (int)Random.Range (1, 3);
			jumpSound.Play ();
			if (1 == coinFlip) {
				this.transform.rotation = Quaternion.Euler (0.0f, 225.0f, 0.0f);
				this.transform.Translate (new Vector3 (0.0f, 1.0f, 1.0f));
				//ApplyDownwardForce ();
			} else {
				this.transform.rotation = Quaternion.Euler (0.0f, 135.0f, 0.0f);
				this.transform.Translate (new Vector3 (0.0f, 1.0f, 1.0f));
				//ApplyDownwardForce ();
			}
		}// else if (collision.gameObject.CompareTag ("Sheep")) {
//			collision.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
//			collision.transform.position = new Vector3 (0.0f, 3.0f, 10.0f);
//			collision.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 225.0f, 0.0f));
//		}
	}
}
