using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.0f;

	public GameObject lifeAvatar1;
	public GameObject lifeAvatar2;
	public GameObject lifeAvatar3;

	public AudioSource dieSound;
	public AudioSource jumpSound;
	public AudioSource fallingSound;

	private bool _canMove = true;
	private bool _isFalling = false;
	private float _startingYPos;
	private int _lives = 3;

	void Start() {
		this.gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
	}

	void Update() {
		if (_canMove) {
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				_canMove = false;
				_startingYPos = this.transform.position.y;
				jumpSound.Play ();
				this.transform.rotation = Quaternion.Euler (0.0f, 225.0f, 0.0f);
				this.transform.Translate (new Vector3 (0.0f, 0.5f, 1.0f));
				//ApplyDownwardForce ();
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				_canMove = false;
				_startingYPos = this.transform.position.y;
				jumpSound.Play ();
				this.transform.rotation = Quaternion.Euler (0.0f, 45.0f, 0.0f);
				this.transform.Translate (new Vector3 (0.0f, 1.3f, 1.0f));
				//ApplyDownwardForce ();
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				_canMove = false;
				_startingYPos = this.transform.position.y;
				jumpSound.Play ();
				this.transform.rotation = Quaternion.Euler (0.0f, 135.0f, 0.0f);
				this.transform.Translate (new Vector3 (0.0f, 0.5f, 1.0f));
				//ApplyDownwardForce ();
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				_canMove = false;
				_startingYPos = this.transform.position.y;
				jumpSound.Play ();
				this.transform.rotation = Quaternion.Euler (0.0f, 315.0f, 0.0f);
				this.transform.Translate (new Vector3 (0.0f, 1.3f, 1.0f));
				//ApplyDownwardForce ();
			}
		}
		if (this.gameObject.transform.position.y < (_startingYPos-1.5f) && !_isFalling) {
			_isFalling = true;
			fallingSound.Play ();
		}
	}

	void ApplyDownwardForce() {
		this.GetComponent<Rigidbody>().AddForce (Vector3.down * speed);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Top Panel")) {
			_canMove = true;
		} else if (collision.gameObject.CompareTag ("Jelly")) {
			dieSound.Play ();
			if (_lives > 0) {
				this.transform.position = new Vector3 (0.0f, 3.0f, 10.0f);
				this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				this.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, 225.0f, 0.0f));
			}
			switch (_lives--) {
			case 1:
				lifeAvatar1.SetActive (false);
				break;
			case 2:
				lifeAvatar2.SetActive (false);
				break;
			case 3:
				lifeAvatar3.SetActive (false);
				break;
			default:
				Time.timeScale = 0.0f;
				break;
			}
		}
	}
}
