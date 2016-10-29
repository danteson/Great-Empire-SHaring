using UnityEngine;
using System.Collections;

public class CharacterUI : MonoBehaviour {

	public int uiActive = 0;
	public int talkCount = 0;
	public Vector3 screenPos;
	public GameObject player;
	public GameObject hpBar;
	public GameObject camTargetObj;

	Rect hpRect;
	Texture2D hpTexture;

	Rect energyRect;
	Texture2D energyTexture;

	public float Hp = 500;
	public float maxHp = 500;

	public float Energy = 500;
	public float maxEnergy = 500;

	public Vector3 point;

	public Transform target;
	public GameObject camObj;
	public GameObject camObjPos;
	public GameObject charBody;
	Camera camera;

	public string talk1 = "";
	public string talk2 = "";
	public string talk3 = "";

	void Start() {
		camera = camObj.GetComponent<Camera> ();
	}

	void Update() {
		screenPos = camera.WorldToScreenPoint(gameObject.transform.position);
		//screenPos = Camera.main.WorldToScreenPoint(target.position);

		hpRect = new Rect (screenPos.x+50, Screen.height - screenPos.y-200, Screen.width / 10, Screen.height / 100);
		hpTexture = new Texture2D (1, 1);
		hpTexture.SetPixel (0, 0, Color.green);
		hpTexture.Apply ();

		energyRect = new Rect (screenPos.x+50, Screen.height - screenPos.y-190, Screen.width / 10, Screen.height / 100);
		energyTexture = new Texture2D (1, 1);
		energyTexture.SetPixel (0, 0, Color.yellow);
		energyTexture.Apply ();

		if (talkCount == 3) {
			talkCount = 0;
		}

		if (Input.GetKeyDown ("f") && Hp > 0) {
			Hp -= 20;
		}

		if (GetComponent<NPCController> ().Distance < 20) {
			if (uiActive == 1) {
				camObj.transform.position = camTargetObj.transform.position;
				camObj.transform.rotation = camTargetObj.transform.rotation;
				charBody.SetActive (false);
				player.GetComponent<PlayerController> ().enabled = false;
			} else {
				camObj.transform.position = camObjPos.transform.position;
				camObj.transform.rotation = camObjPos.transform.rotation;
				charBody.SetActive (true);
				player.GetComponent<PlayerController> ().enabled = true;
			}
		}

		if (Input.GetKeyDown ("f") && GetComponent<NPCController> ().Distance < 10) {
			uiActive = 1;
			player.GetComponent<PlayerController> ().toggleOrbit = 1;
		}
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (1)) {
			uiActive = 1;
			player.GetComponent<PlayerController> ().toggleOrbit = 1;
		}
	}

	void OnGUI () {
		if (GetComponent<NPCController> ().Distance < 10 && uiActive == 0) {
			GUI.Box(new Rect(Screen.width/2, Screen.height/2, 240, 30), "F to speak!");
		}

		if (uiActive == 1) {
			if (talkCount == 0) {
				GUI.Box(new Rect(screenPos.x-280, Screen.height - screenPos.y-Screen.height/2.2f, 240, 200), gameObject.name.ToString()+" : "+talk1.ToString());
			}

			if (talkCount == 1) {
				GUI.Box(new Rect(screenPos.x-280, Screen.height - screenPos.y-Screen.height/2.2f, 240, 200), talk2.ToString());
			}

			if (talkCount == 2) {
				GUI.Box(new Rect(screenPos.x-280, Screen.height - screenPos.y-Screen.height/2.2f, 240, 200), talk3.ToString());
			}

			if (GUI.Button (new Rect (screenPos.x-270, Screen.height - screenPos.y-Screen.height/3.5f, 70, 30), "Cancel")) {
				uiActive = 0;
				player.GetComponent<PlayerController> ().toggleOrbit = 0;
			}

			if (GUI.Button (new Rect (screenPos.x - 195, Screen.height - screenPos.y-Screen.height/3.5f, 70, 30), "Follow") && GetComponent<NPCController>().chaseBool == false) {
				if (player.GetComponent<PartySystem>().canParty) {
					player.GetComponent<PartySystem>().partyCount += 1;
					GetComponent<NPCController>().chaseBool = true;
					talkCount = 1;
					if (player.GetComponent<PartySystem>().partymember1 == null) {
						player.GetComponent<PartySystem>().partymember1 = gameObject;
					} else if (player.GetComponent<PartySystem>().partymember2 == null) {
						player.GetComponent<PartySystem>().partymember2 = gameObject;
					} else if (player.GetComponent<PartySystem>().partymember3 == null) {
						player.GetComponent<PartySystem>().partymember3 = gameObject;
					} else if (player.GetComponent<PartySystem>().partymember4 == null) {
						player.GetComponent<PartySystem>().partymember4 = gameObject;
					}
				}
			}

			if (GUI.Button (new Rect (screenPos.x - 120, Screen.height - screenPos.y-Screen.height/3.5f, 70, 30), "Unfollow")) {
				GetComponent<NPCController>().chaseBool = false;
				talkCount = 2;

				if (player.GetComponent<PartySystem>().partymember1 == gameObject) {
					player.GetComponent<PartySystem>().partymember1 = null;
					player.GetComponent<PartySystem>().partyCount -= 1;
				}

				if (player.GetComponent<PartySystem>().partymember2 == gameObject) {
					player.GetComponent<PartySystem>().partymember2 = null;
					player.GetComponent<PartySystem>().partyCount -= 1;
				}

				if (player.GetComponent<PartySystem>().partymember3 == gameObject) {
					player.GetComponent<PartySystem>().partymember3 = null;
					player.GetComponent<PartySystem>().partyCount -= 1;
				}

				if (player.GetComponent<PartySystem>().partymember4 == gameObject) {
					player.GetComponent<PartySystem>().partymember4 = null;
					player.GetComponent<PartySystem>().partyCount -= 1;
				}
			}


		}
		if (GetComponent<NPCController> ().Distance < 20) {
			float ratioHP = Hp / maxHp;
			float rectWidthHP = ratioHP * Screen.width / 10;
			hpRect.width = rectWidthHP;
			GUI.DrawTexture (hpRect, hpTexture);

			float ratioEnergy = Energy / maxEnergy;
			float rectWidthEnergy = ratioEnergy * Screen.width / 10;
			energyRect.width = rectWidthEnergy;
			GUI.DrawTexture (energyRect, energyTexture);
		}

	}
}
