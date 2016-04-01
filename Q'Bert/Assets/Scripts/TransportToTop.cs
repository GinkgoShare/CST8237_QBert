using UnityEngine;
using System.Collections;

public class TransportToTop : MonoBehaviour {

	public float speed;
	public AudioSource transportSound;

	private Collision _other;
	private float _startTime;
	private Vector3 _initPosition;
	private float _journeyLength;
	private bool _canMove;
	private bool _isFirstCollision;
	private Vector3 _endPosition;

	void Start() {
		if (this.gameObject.tag == "Trans1") {
			_endPosition = new Vector3 (-0.7f, 3.0f, 10.7f);
			_initPosition = new Vector3 (-3.6f, -2.0f, 8.0f);
		} else {
			_endPosition = new Vector3 (0.7f, 3.0f, 10.7f);
			_initPosition = new Vector3 (3.6f, -2.0f, 8.0f);
		}
		Init ();
	}

	public void Init() {
		_canMove = false;
		_startTime = Time.time;
		_isFirstCollision = true;
		this.gameObject.SetActive (true);
		this.transform.position = _initPosition;
		_journeyLength = Vector3.Distance(this.transform.position, _endPosition);
	}

	void Update() {
		if (_canMove) {
			float distCovered = (Time.time - _startTime) * speed;
			float fracJourney = distCovered / _journeyLength;
			transform.position = Vector3.Lerp(this.transform.position, _endPosition, fracJourney);
			_other.transform.position = Vector3.Lerp(this.transform.position, _endPosition, fracJourney);
		}
		if (transform.position == _endPosition && !transportSound.isPlaying) {
			_canMove = false;
			_other.transform.Translate (new Vector3 (0.0f, 1.3f, 1.0f));
			this.gameObject.SetActive (false);
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Sheep")) {
			_canMove = true;
			_other = collision;
			if (this.gameObject.tag == "Trans1") {
				_other.transform.rotation = Quaternion.Euler (0.0f, 135.0f, 0.0f);
			} else {
				_other.transform.rotation = Quaternion.Euler (0.0f, 225.0f, 0.0f);
			}
			if (_isFirstCollision) { // ensure sound is only played once incase of replays
				_isFirstCollision = false;
				transportSound.Play ();
			}
		}
	}
}
