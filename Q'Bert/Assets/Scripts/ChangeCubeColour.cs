using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeCubeColour : MonoBehaviour {

	private bool _hasChangedColor;
	private static int _landedCount;
	private static bool _canChangeColour;

	void Start() {
		Init ();
	}

	public void Init() {
		_landedCount = 0;
		_hasChangedColor = false;
		_canChangeColour = false;
	}

	public bool HasChangedColour() {
		return _hasChangedColor;
	}

	public void SetHasChangedColour(bool hasChangedColour) {
		_hasChangedColor = hasChangedColour;
	}

	public bool CanChangeColour() {
		return _canChangeColour;
	}

	public void SetCanChangeColour(bool canChangeColour) {
		_canChangeColour = canChangeColour;
	}

	public int GetLandedCount() {
		return _landedCount;
	}

	public void SetLandedCount(int landedCount) {
		_landedCount = landedCount;
	} 

	public void ChangeMaterial(Material material) {
		this.GetComponent<MeshRenderer> ().material = material;
	}
}
