using UnityEngine;
using System.Collections;

public class TransportToTop : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
//		Debug.Log (collision.transform.rotation.eulerAngles.y);
//		if (collision.transform.rotation.eulerAngles.y > 314.0f && collision.transform.rotation.eulerAngles.y < 316.0f)
//			collision.transform.rotation = Quaternion.Euler(0.0f, 45.0f, 0.0f);
//		else
//			collision.transform.rotation = Quaternion.Euler(0.0f, 315.0f, 0.0f);
//		this.transform.Translate(new Vector3(0.0f, 3.0f, 4.0f));
//		collision.transform.Translate(new Vector3(0.0f, 3.0f, 4.0f));
//		Debug.Log (collision.transform.rotation.eulerAngles.y);
//		if (collision.transform.rotation.eulerAngles.y > 314.0f && collision.transform.rotation.eulerAngles.y < 316.0f)
//			collision.transform.rotation = Quaternion.Euler(0.0f, 225.0f, 0.0f);
//		else
//			collision.transform.rotation = Quaternion.Euler(0.0f, 135.0f, 0.0f);

		this.transform.position = new Vector3 (0.0f, 3.0f, 10.0f);
		collision.transform.position = new Vector3 (0.0f, 3.0f, 10.0f);
		this.gameObject.SetActive (false);
	}
}
