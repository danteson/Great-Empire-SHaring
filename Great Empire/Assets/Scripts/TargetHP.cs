using UnityEngine;
using System.Collections;

public class TargetHP : MonoBehaviour {

public int HP = 9;
public bool AttackRange = false;
public Transform Player;


void Update() {
	if (HP < 1) {
		Destroy(this.gameObject);
	}
	if (HP <0) {
		HP = 0;
	}
		if (Input.GetMouseButtonDown(0) && AttackRange == true && Player.GetComponent<PlayerController> ().walking == false) {
		HP -=3;
	}
}


void OnTriggerEnter(Collider other){


	if(other.gameObject.name == "AttackArea"){
		AttackRange = true;
	}
	if(other.gameObject.tag == "Fireball"){
		HP -=5;
	}
}



	void OnTriggerExit(Collider other){


	if(other.gameObject.name == "AttackArea"){
		AttackRange = false;
		}}}