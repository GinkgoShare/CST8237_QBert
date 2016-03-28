using UnityEngine;
using System.Collections;

public class TransportToTop : MonoBehaviour {

	public float speed = 1.0F;

	private Collision _other;
	private float _startTime;
	private float _journeyLength;
	private bool _canMove = false;
	private Vector3 _endPosition = new Vector3 (0.0f, 3.0f, 10.0f);

	void Start() {
		_startTime = Time.time;
		_journeyLength = Vector3.Distance(this.transform.position, _endPosition);
	}

	void Update() {
		if (_canMove) {
			float distCovered = (Time.time - _startTime) * speed;
			float fracJourney = distCovered / _journeyLength;
			transform.position = Vector3.Lerp(this.transform.position, _endPosition, fracJourney);
			_other.transform.position = Vector3.Lerp(this.transform.position, _endPosition, fracJourney);
		}
		if (transform.position == _endPosition) this.gameObject.SetActive (false);
	}

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

		//this.transform.position = new Vector3 (0.0f, 3.0f, 10.0f);
		//collision.transform.position = new Vector3 (0.0f, 3.0f, 10.0f);

		//float distCovered = (Time.time - startTime) * speed;
		//float fracJourney = distCovered / journeyLength;
		//transform.position = Vector3.Lerp(this.transform.position, endPosition, fracJourney);
		_canMove = true;
		_other = collision;

		//this.gameObject.SetActive (false);
	}
}
