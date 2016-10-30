using UnityEngine;
using System.Collections;

public class PartySlots : MonoBehaviour {


	public Transform TargetPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = TargetPlayer.transform.position;
	
	}
}
