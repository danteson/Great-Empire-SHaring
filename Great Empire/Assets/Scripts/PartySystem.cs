using UnityEngine;
using System.Collections;

public class PartySystem : MonoBehaviour {

	public GameObject partymember1;
	public GameObject partymember2;
	public GameObject partymember3;
	public GameObject partymember4;

	public int partyCount = 0;
	public bool canParty = true;

	Rect hpRect1;
	Texture2D hpTexture1;

	Rect hpRect2;
	Texture2D hpTexture2;

	Rect hpRect3;
	Texture2D hpTexture3;

	Rect hpRect4;
	Texture2D hpTexture4;

	public float y1;
	public float y2;
	public float y3;
	public float y4;
	public float y5;
	public float y6;

	void Start () {
		hpRect1 = new Rect (Screen.width / 50, Screen.height / 10f, Screen.width / 10, Screen.height / 100);
		hpTexture1 = new Texture2D (1, 1);
		hpTexture1.SetPixel (0, 0, Color.green);
		hpTexture1.Apply ();

		hpRect2 = new Rect (Screen.width / 50, Screen.height / 6.4f, Screen.width / 10, Screen.height / 100);
		hpTexture2 = new Texture2D (1, 1);
		hpTexture2.SetPixel (0, 0, Color.green);
		hpTexture2.Apply ();

		hpRect3 = new Rect (Screen.width / 50, Screen.height / 4.6f, Screen.width / 10, Screen.height / 100);
		hpTexture3 = new Texture2D (1, 1);
		hpTexture3.SetPixel (0, 0, Color.green);
		hpTexture3.Apply ();

		hpRect4 = new Rect (Screen.width / 50, Screen.height / 3.55f, Screen.width / 10, Screen.height / 100);
		hpTexture4 = new Texture2D (1, 1);
		hpTexture4.SetPixel (0, 0, Color.green);
		hpTexture4.Apply ();
	}

	void Update () {
		if (partyCount < 4) {
			canParty = true;
		} else {
			canParty = false;
		}
	}


	void OnGUI () {
		if (partymember1 != null) {
			GUI.Box(new Rect(Screen.width / 100, Screen.height / 15f, Screen.width / 8, Screen.height / 20),partymember1.name );
			float ratioHP = partymember1.GetComponent<CharacterUI>().Hp / partymember1.GetComponent<CharacterUI>().maxHp;
			float rectWidthHP = ratioHP*Screen.width / 10;
			hpRect1.width = rectWidthHP;
			GUI.DrawTexture (hpRect1, hpTexture1);
		}

		if (partymember2 != null) {
			GUI.Box(new Rect(Screen.width / 100, Screen.height / 8f, Screen.width / 8, Screen.height / 20),partymember2.name );
			float ratioHP = partymember2.GetComponent<CharacterUI>().Hp / partymember2.GetComponent<CharacterUI>().maxHp;
			float rectWidthHP = ratioHP*Screen.width / 10;
			hpRect2.width = rectWidthHP;
			GUI.DrawTexture (hpRect2, hpTexture2);
		}

		if (partymember3 != null) {
			GUI.Box(new Rect(Screen.width / 100, Screen.height / 5.4f, Screen.width / 8, Screen.height / 20),partymember3.name );
			float ratioHP = partymember3.GetComponent<CharacterUI>().Hp / partymember3.GetComponent<CharacterUI>().maxHp;
			float rectWidthHP = ratioHP*Screen.width / 10;
			hpRect3.width = rectWidthHP;
			GUI.DrawTexture (hpRect3, hpTexture3);
		}

		if (partymember4 != null) {
			GUI.Box(new Rect(Screen.width / 100, Screen.height / 4f, Screen.width / 8, Screen.height / 20),partymember4.name );
			float ratioHP = partymember4.GetComponent<CharacterUI>().Hp / partymember4.GetComponent<CharacterUI>().maxHp;
			float rectWidthHP = ratioHP*Screen.width / 10;
			hpRect4.width = rectWidthHP;
			GUI.DrawTexture (hpRect4, hpTexture4);
		}
	}

}
