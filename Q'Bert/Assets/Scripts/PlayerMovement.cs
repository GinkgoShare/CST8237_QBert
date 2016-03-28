using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.0f;

	private bool _canMove = true;

	void Update() {
		if (_canMove) {
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				_canMove = false;
				this.transform.rotation = Quaternion.Euler (0.0f, 225.0f, 0.0f);
				//this.transform.position = new Vector3 (this.transform.position.x - 0.7f, this.transform.position.y + 0.3f, this.transform.position.z - 0.7f);
				this.transform.Translate (new Vector3 (0.0f, 0.4f, 1.0f));
				//this.transform.Translate(new Vector3(0.0f, -1.0f, 0.0f));
				ApplyDownwardForce ();
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				_canMove = false;
				this.transform.rotation = Quaternion.Euler (0.0f, 45.0f, 0.0f);
				//this.transform.position = new Vector3 (this.transform.position.x + 0.7f, this.transform.position.y + 1.0f, this.transform.position.z + 0.7f);
				this.transform.Translate (new Vector3 (0.0f, 1.2f, 1.0f));
				//this.transform.Translate(new Vector3(0.0f, -1.0f, 0.0f));
				ApplyDownwardForce ();
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				_canMove = false;
				this.transform.rotation = Quaternion.Euler (0.0f, 135.0f, 0.0f);
				//this.transform.position = new Vector3 (this.transform.position.x + 0.7f, this.transform.position.y + 0.3f, this.transform.position.z - 0.7f);
				this.transform.Translate (new Vector3 (0.0f, 0.4f, 1.0f));
				//this.transform.Translate(new Vector3(0.0f, -1.0f, 0.0f));
				ApplyDownwardForce ();
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				_canMove = false;
				this.transform.rotation = Quaternion.Euler (0.0f, 315.0f, 0.0f);
				//this.transform.position = new Vector3 (this.transform.position.x - 0.7f, this.transform.position.y + 1.0f, this.transform.position.z + 0.7f);
				this.transform.Translate (new Vector3 (0.0f, 1.2f, 1.0f));
				//this.transform.Translate(new Vector3(0.0f, -1.0f, 0.0f));
				ApplyDownwardForce ();
			}
		}
	}

	void ApplyDownwardForce() {
		this.GetComponent<Rigidbody>().AddForce (Vector3.down * speed);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Cube")) {
			_canMove = true;
		}
	}
}
