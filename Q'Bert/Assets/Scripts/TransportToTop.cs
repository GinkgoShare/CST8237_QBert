using UnityEngine;
using System.Collections;

public class TransportToTop : MonoBehaviour {

	public float speed = 1.0F;
	public AudioSource transportSound;

	private Collision _other;
	private float _startTime;
	private float _journeyLength;
	private bool _canMove = false;
	private bool _isFirstCollision = true;
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
		if (transform.position == _endPosition && !transportSound.isPlaying) this.gameObject.SetActive (false);
	}

	void OnCollisionEnter(Collision collision) {
		_canMove = true;
		_other = collision;
		if (_isFirstCollision) {
			_isFirstCollision = false;
			transportSound.Play ();
		}
	}
}
