using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	public float speed = 1.0f;

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
		int coinFlip = (int)Random.Range (1, 3);
		if (1 == coinFlip) {
			this.transform.rotation = Quaternion.Euler (0.0f, 225.0f, 0.0f);
			this.transform.Translate (new Vector3 (0.0f, 1.0f, 1.0f));
			//ApplyDownwardForce ();
		} else {
			this.transform.rotation = Quaternion.Euler (0.0f, 135.0f, 0.0f);
			this.transform.Translate (new Vector3 (0.0f, 1.0f, 1.0f));
			//ApplyDownwardForce ();
		}
	}
}
