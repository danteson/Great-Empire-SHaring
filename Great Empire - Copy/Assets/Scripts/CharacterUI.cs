using UnityEngine;
using System.Collections;

public class CharacterUI : MonoBehaviour {

	public int uiActive = 0;
	public int talkCount = 0;
	public Vector2 mousePosition;
	public Vector2 screenPos;

	public Vector3 point;

	public Transform target;
	public GameObject camObj;
	Camera camera;

	public string talk1 = "";
	public string talk2 = "";
	public string talk3 = "";

	void Start() {
		camera = camObj.GetComponent<Camera>();
	}

	void Update() {
		screenPos = camera.WorldToScreenPoint(target.position);
		point = Camera.main.WorldToScreenPoint(target.position);

		if (talkCount == 3) {
			talkCount = 0;
		}
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (1)) {
			screenPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
			uiActive = 1;
		}
	}

	void OnGUI () {
		if (uiActive == 1) {
			if (talkCount == 0) {
				GUI.Box(new Rect(screenPos.x-10, Screen.height/2-10, 240, 200), talk1.ToString());
			}

			if (talkCount == 1) {
				GUI.Box(new Rect(screenPos.x-10, Screen.height/2-10, 240, 200), talk2.ToString());
			}

			if (talkCount == 2) {
				GUI.Box(new Rect(screenPos.x-10, Screen.height/2-10, 240, 200), talk3.ToString());
			}

			if (GUI.Button (new Rect (screenPos.x, Screen.height/2+150, 70, 30), "Cancel")) {
				uiActive = 0;
			}

			if (GUI.Button (new Rect (screenPos.x+75, Screen.height/2+150, 70, 30), "Follow")) {
				GetComponent<NPCController>().chaseBool = true;
				talkCount = 1;
			}

			if (GUI.Button (new Rect (screenPos.x+150, Screen.height/2+150, 70, 30), "Unfollow")) {
				GetComponent<NPCController>().chaseBool = false;
				talkCount = 2;
			}


		}
	}
}
