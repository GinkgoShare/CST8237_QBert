using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	public Text scoreText;
	public Text levelText;
	public Text gameOverText;

	public GameObject lifeAvatar1;
	public GameObject lifeAvatar2;
	public GameObject lifeAvatar3;

	public Material cube1;
	public Material cube2;
	public Material cube3;
	public Material panel1;
	public Material panel2;
	public Material panel3;

	public AudioSource winSound;
	public AudioSource dieSound;
	public AudioSource jumpSound;
	public AudioSource splatSound;
	public AudioSource fallingSound;
	public AudioSource gameOverSound;

	private int _level;
	private int _lives;
	private float _waitForNextLevel;
	private bool _hasBeatLevel;
	private bool _canMove;
	private bool _isFalling;
	private float _startingYPos;
	private float _normalTimeScale;
	private GameObject[] _cubes;
	private GameObject[] _cubePanels;
	private bool _isGameOver;

	void Start() {
		_normalTimeScale = Time.timeScale;
		this.gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
		_cubes = GameObject.FindGameObjectsWithTag("Cube");
		_cubePanels = GameObject.FindGameObjectsWithTag("Top Panel");
		InitGame ();
	}

	void InitGame() {
		_level = 1;
		_lives = 3;
		_canMove = false;
		_isFalling = false;
		_isGameOver = false;
		scoreText.text = "000000";
		lifeAvatar1.SetActive (true);
		lifeAvatar2.SetActive (true);
		lifeAvatar3.SetActive (true);
		gameOverText.gameObject.SetActive(false);
		InitNewLevel ();
	}

	void InitNewLevel() {
		_hasBeatLevel = false;
		levelText.text = "Level " + _level;
		switch (_level % 3) {
		case 0:
			foreach (var cube in _cubes) {
				cube.GetComponent<MeshRenderer> ().material = cube3;
			}
			foreach (var panel in _cubePanels) {
				panel.GetComponent<MeshRenderer> ().material = panel3;
				panel.GetComponent<ChangeCubeColour> ().SetLandedCount (0);
				panel.GetComponent<ChangeCubeColour> ().SetHasChangedColour (false);
				panel.GetComponent<ChangeCubeColour> ().SetCanChangeColour (false);
			}
			break;
		case 1:
			foreach (var cube in _cubes) {
				cube.GetComponent<MeshRenderer> ().material = cube1;
			}
			foreach (var panel in _cubePanels) {
				panel.GetComponent<MeshRenderer> ().material = panel1;
				panel.GetComponent<ChangeCubeColour> ().SetLandedCount (0);
				panel.GetComponent<ChangeCubeColour> ().SetHasChangedColour (false);
				panel.GetComponent<ChangeCubeColour> ().SetCanChangeColour (false);
			}
			break;
		case 2:
			foreach (var cube in _cubes) {
				cube.GetComponent<MeshRenderer> ().material = cube2;
			}
			foreach (var panel in _cubePanels) {
				panel.GetComponent<MeshRenderer> ().material = panel2;
				panel.GetComponent<ChangeCubeColour> ().SetLandedCount (0);
				panel.GetComponent<ChangeCubeColour> ().SetHasChangedColour (false);
				panel.GetComponent<ChangeCubeColour> ().SetCanChangeColour (false);
			}
			break;
		}
		Time.timeScale = _normalTimeScale;
		this.transform.position = new Vector3 (0.0f, 3.0f, 10.0f);
		this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		this.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, 225.0f, 0.0f));
	}

	void Update() {
		if (_canMove) {
			MovePlayer ();
		}
		if (this.gameObject.transform.position.y < (_startingYPos-1.5f) && !_isFalling) {
			_isFalling = true;
			fallingSound.Play ();
		}
		//Debug.Log (string.Format ("Wait Time: {0}, Current Time: {1}, Art: {2}", _waitForNextLevel, Time.time, (Time.time - 5.0f)));
		if (_hasBeatLevel) {
			_level++;
			InitNewLevel ();
		}
		if (_isGameOver && !gameOverSound.isPlaying) {
			Time.timeScale = _normalTimeScale;
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Menu");
		}
	}

	void MovePlayer() {
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



	void ApplyDownwardForce() {
		this.GetComponent<Rigidbody>().AddForce (Vector3.down * speed);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Top Panel")) {
			_isFalling = false;
			_canMove = true;
			if (!(collision.gameObject.GetComponent<ChangeCubeColour>().HasChangedColour())) {
				if (collision.gameObject.GetComponent<ChangeCubeColour>().CanChangeColour()) {
					collision.gameObject.GetComponent<ChangeCubeColour> ().SetHasChangedColour (true);
					scoreText.text = string.Format("{0:000000}", (int.Parse (scoreText.text) + 25));
					switch (_level % 3) {
					case 0:
						collision.gameObject.GetComponent<ChangeCubeColour> ().ChangeMaterial(panel1);
						break;
					case 1:
						collision.gameObject.GetComponent<ChangeCubeColour> ().ChangeMaterial(panel2);
						break;
					case 2:
						collision.gameObject.GetComponent<ChangeCubeColour> ().ChangeMaterial(panel3);
						break;
					}
					collision.gameObject.GetComponent<ChangeCubeColour> ().SetLandedCount (
						collision.gameObject.GetComponent<ChangeCubeColour> ().GetLandedCount() + 1); // increment landed cube count
					
					if (collision.gameObject.GetComponent<ChangeCubeColour> ().GetLandedCount() == 28) { // total number of cubes
						_waitForNextLevel = Time.time;
						Time.timeScale = 0.0f;
						winSound.Play ();
						_hasBeatLevel = true;
					}
				} else {
					collision.gameObject.GetComponent<ChangeCubeColour> ().SetCanChangeColour(true);
				}
			}
		} else if (collision.gameObject.CompareTag ("Jelly")) {
			PlayerDies (false);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Boundary")) {
			PlayerDies (true);
		}
	}

	void PlayerDies(bool isSplat) {
		if (isSplat) splatSound.Play ();
		else dieSound.Play ();
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
			GameOver ();
			break;
		}
	}

	void GameOver() {
		_isGameOver = true;
		gameOverSound.Play ();
		Time.timeScale = 0.0f;
		gameOverText.gameObject.SetActive(true);
	}

	public int GetLevel() {
		return _level;
	} 
}
