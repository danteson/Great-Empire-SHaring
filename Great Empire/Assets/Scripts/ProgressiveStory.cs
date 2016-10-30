using UnityEngine;
using System.Collections;

public class ProgressiveStory : MonoBehaviour {


	public int canSpeak;
	public int uiActive;

	void Start () {
	
	}

	void Update () {
		if (canSpeak == 1 && Input.GetKeyDown ("f")) {
			uiActive = 1;
		}
	}

	void OnGUI () {
		if (uiActive == 1) {
			GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, 240, 30), "");
		}

		if (canSpeak == 1 && uiActive == 0) {
			GUI.Box (new Rect (280, 200, 240, 200), "F to speak");
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "FtoSpeak") {
			canSpeak = 1;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "FtoSpeak") {
			canSpeak = 0;
		}
	}
}
