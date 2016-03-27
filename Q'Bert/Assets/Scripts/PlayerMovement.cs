using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	void Update() {
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			this.transform.rotation = Quaternion.Euler(0.0f, 225.0f, 0.0f);
			//this.transform.position = new Vector3 (this.transform.position.x - 0.7f, this.transform.position.y + 0.3f, this.transform.position.z - 0.7f);
			this.transform.Translate(new Vector3(0.0f, 1.0f, 1.0f));
			this.transform.Translate(new Vector3(0.0f, -1.3f, 0.0f));
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			this.transform.rotation = Quaternion.Euler(0.0f, 45.0f, 0.0f);
			//this.transform.position = new Vector3 (this.transform.position.x + 0.7f, this.transform.position.y + 1.0f, this.transform.position.z + 0.7f);
			this.transform.Translate(new Vector3(0.0f, 1.5f, 1.0f));
			this.transform.Translate(new Vector3(0.0f, -0.6f, 0.0f));
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			this.transform.rotation = Quaternion.Euler(0.0f, 135.0f, 0.0f);
			//this.transform.position = new Vector3 (this.transform.position.x + 0.7f, this.transform.position.y + 0.3f, this.transform.position.z - 0.7f);
			this.transform.Translate(new Vector3(0.0f, 1.0f, 1.0f));
			this.transform.Translate(new Vector3(0.0f, -1.3f, 0.0f));
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			this.transform.rotation = Quaternion.Euler(0.0f, 315.0f, 0.0f);
			//this.transform.position = new Vector3 (this.transform.position.x - 0.7f, this.transform.position.y + 1.0f, this.transform.position.z + 0.7f);
			this.transform.Translate(new Vector3(0.0f, 1.5f, 1.0f));
			this.transform.Translate(new Vector3(0.0f, -0.6f, 0.0f));
		}
	}
}
