using UnityEngine;
using System.Collections;

public class SpawnJellies : MonoBehaviour {

	public int delay;

	public GameObject blueJelly;
	public GameObject redJelly;
	public GameObject purpleJelly;

	private float _timer;

	void Start() {
		_timer = Time.time + delay;
	}

	void Update () {
		if (_timer < Time.time) {
			int chooseSide = (int)Random.Range (1, 3);
			int chooseJelly = (int)Random.Range (0, 4);
			switch (chooseJelly) {
			case 0:
				Instantiate(blueJelly, new Vector3((chooseSide == 1 ? -0.7f : 0.7f), 4.0f, 9.3f), Quaternion.Euler(new Vector3(0.0f, (chooseSide == 1 ? 135.0f : 225.0f), 0.0f)));
				break;
			case 1:
				Instantiate(redJelly, new Vector3((chooseSide == 1 ? -0.7f : 0.7f), 4.0f, 9.3f), Quaternion.Euler(new Vector3(0.0f, (chooseSide == 1 ? 135.0f : 225.0f), 0.0f)));
				break;
			default:
				Instantiate(purpleJelly, new Vector3((chooseSide == 1 ? -0.7f : 0.7f), 4.0f, 9.3f), Quaternion.Euler(new Vector3(0.0f, (chooseSide == 1 ? 135.0f : 225.0f), 0.0f)));
				break;
			}
			_timer = Time.time + delay; 
		}
	}
}
