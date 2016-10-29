using UnityEngine;
using System.Collections;

public class NPCRandomTalk : MonoBehaviour {

	public string talk1part1;
	public string talk1part2;
	public string talk1part3;

	public string talk2part1;
	public string talk2part2;
	public string talk2part3;

	public string talk3part1;
	public string talk3part2;
	public string talk3part3;

	public string talk4part1;
	public string talk4part2;
	public string talk4part3;


	public string MainString;
	public string TalkingChar;

	public int charNumber;

	public int talkNumber;

	public float timeDelay;

	public float yPosition = 1;

	public bool talkTrue = false;
	public bool rollOn = false;
	public bool talking = false;

	public float x;
	public float y;

	void Start () {
		MainString = null;
	}

	void Update () {
		if (rollOn) {
			yPosition += Time.deltaTime*0.8f;
			StartCoroutine (StopRoll (0.3f));
		}


		if (GetComponent<PartySystem> ().partyCount > 0 && talking == false) {
			WaitTime ();
			talking = true;
		}

	}

	void OnGUI () {
		if (talkTrue) {
			GUI.Box (new Rect (Screen.width / 100, Screen.height / yPosition, 240, 100), TalkingChar+" : "+MainString);
		}
	}

	void WaitTime () {
		timeDelay = Random.Range (20, 40);
		StartCoroutine (DelayBetweenTalks (timeDelay));
	}

	IEnumerator DelayBetweenTalks (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		talkNumber = Random.Range (1, 5);
		if (talkNumber == 1) { Talks1 (); }
		if (talkNumber == 2) { Talks2 (); }
		if (talkNumber == 3) { Talks3 (); }
		if (talkNumber == 4) { Talks4 (); }
	}

	void ChooseChar () {
		charNumber = Random.Range (1, 5);
	}
		
	IEnumerator TalkWait (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		talkTrue = false;
		yPosition = 1;
	}

	IEnumerator StopRoll (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		rollOn = false;
	}

	void PickCharacter() {
		#region Pick Character
		if (charNumber == 1) {
			if (GetComponent<PartySystem>().partymember1 != null) { TalkingChar = GetComponent<PartySystem>().partymember1.name; }
			else if (GetComponent<PartySystem>().partymember2 != null) { TalkingChar = GetComponent<PartySystem>().partymember2.name; }
			else if (GetComponent<PartySystem>().partymember3 != null) { TalkingChar = GetComponent<PartySystem>().partymember3.name; }
			else if (GetComponent<PartySystem>().partymember4 != null) { TalkingChar = GetComponent<PartySystem>().partymember4.name; }
		}

		if (charNumber == 2) {
			if (GetComponent<PartySystem>().partymember2 != null) { TalkingChar = GetComponent<PartySystem>().partymember2.name; }
			else if (GetComponent<PartySystem>().partymember1 != null) { TalkingChar = GetComponent<PartySystem>().partymember1.name; }
			else if (GetComponent<PartySystem>().partymember3 != null) { TalkingChar = GetComponent<PartySystem>().partymember3.name; }
			else if (GetComponent<PartySystem>().partymember4 != null) { TalkingChar = GetComponent<PartySystem>().partymember4.name; }
		}

		if (charNumber == 3) {
			if (GetComponent<PartySystem>().partymember3 != null) { TalkingChar = GetComponent<PartySystem>().partymember3.name; }
			else if (GetComponent<PartySystem>().partymember1 != null) { TalkingChar = GetComponent<PartySystem>().partymember1.name; }
			else if (GetComponent<PartySystem>().partymember2 != null) { TalkingChar = GetComponent<PartySystem>().partymember2.name; }
			else if (GetComponent<PartySystem>().partymember4 != null) { TalkingChar = GetComponent<PartySystem>().partymember4.name; }
		}

		if (charNumber == 4) {
			if (GetComponent<PartySystem>().partymember4 != null) { TalkingChar = GetComponent<PartySystem>().partymember4.name; }
			else if (GetComponent<PartySystem>().partymember1 != null) { TalkingChar = GetComponent<PartySystem>().partymember1.name; }
			else if (GetComponent<PartySystem>().partymember2 != null) { TalkingChar = GetComponent<PartySystem>().partymember2.name; }
			else if (GetComponent<PartySystem>().partymember3 != null) { TalkingChar = GetComponent<PartySystem>().partymember3.name; }
		}
		#endregion
	}

	#region Talk 1
	public void Talks1 () {
		ChooseChar ();
		talkTrue = true;
		rollOn = true;
		StartCoroutine (TalkWait (3.0f));
		PickCharacter ();
		if (MainString == null) {
			StartCoroutine (ActivateT1P2 (3.1f));
			MainString = talk1part1;
			Debug.Log ("work");
		}
	}

	IEnumerator ActivateT1P2 (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Talks1 ();
		MainString = talk1part2;
		StartCoroutine (ActivateT1P3 (3.1f));
	}

	IEnumerator ActivateT1P3 (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Talks1 ();
		MainString = talk1part3;
		StartCoroutine (CancelTalk (3.1f));
	}
	#endregion

	#region Talk 2
	public void Talks2 () {
		ChooseChar ();
		talkTrue = true;
		rollOn = true;
		StartCoroutine (TalkWait (3.0f));
		PickCharacter ();
		if (MainString == null) {
			StartCoroutine (ActivateT2P2 (3.1f));
			MainString = talk2part1;
			Debug.Log ("work");
		}
	}

	IEnumerator ActivateT2P2 (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Talks2 ();
		MainString = talk2part2;
		StartCoroutine (ActivateT2P3 (3.1f));
	}

	IEnumerator ActivateT2P3 (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Talks2 ();
		MainString = talk2part3;
		StartCoroutine (CancelTalk (3.1f));
	}
	#endregion

	#region Talk 3
	public void Talks3 () {
		ChooseChar ();
		talkTrue = true;
		rollOn = true;
		StartCoroutine (TalkWait (3.0f));
		PickCharacter ();
		if (MainString == null) {
			StartCoroutine (ActivateT3P2 (3.1f));
			MainString = talk3part1;
			Debug.Log ("work");
		}
	}

	IEnumerator ActivateT3P2 (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Talks3 ();
		MainString = talk3part2;
		StartCoroutine (ActivateT3P3 (3.1f));
	}

	IEnumerator ActivateT3P3 (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Talks3 ();
		MainString = talk3part3;
		StartCoroutine (CancelTalk (3.1f));
	}
	#endregion

	#region Talk 4
	public void Talks4 () {
		ChooseChar ();
		talkTrue = true;
		rollOn = true;
		StartCoroutine (TalkWait (3.0f));
		PickCharacter ();
		if (MainString == null) {
			StartCoroutine (ActivateT4P2 (3.1f));
			MainString = talk4part1;
			Debug.Log ("work");
		}
	}

	IEnumerator ActivateT4P2 (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Talks4 ();
		MainString = talk4part2;
		StartCoroutine (ActivateT4P3 (3.1f));
	}

	IEnumerator ActivateT4P3 (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Talks4 ();
		MainString = talk4part3;
		StartCoroutine (CancelTalk (3.1f));
	}
	#endregion

	IEnumerator CancelTalk (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		MainString = null;
		talking = false;
	}

}
