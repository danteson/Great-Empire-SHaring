﻿using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
	
	public float Distance = 0f;
	public float Distance2 = 0f;
	public Transform TargetPlayer;
	public Transform PartySlot1;
	public Transform PartySlot2;
	public Transform PartySlot3;
	public Transform PartySlot4;
	public Transform Player;
	public float lookAtDistance = 25.0f;
	public float chaseRange = 15.0f;
	public float attackRange = 1.5f;
	public float moveSpeed = 5.0f;
	public float Damping = 6.0f;
	public float attacktime;
	public int attackRepeatTime = 1;
	public int chaseAgain = 20;
	public bool chaseAgainCheck = true;

	public bool chaseBool = false;

	public float gravity1 = 20.0f;
	
	private Vector3 moveDirection = Vector3.zero;
	
	public int TheDammage = 40;

	public bool bolean;

	public Vector3 playerPos;
	
	public int PlayerXpos;
	public int PlayerZpos;



	// Use this for initialization
	void Start () {
		attacktime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		//if (TargetPlayer.GetComponent<PartySystem> ().partymember1 == gameObject) {PlayerXpos = 0;PlayerZpos = 30;}
		//if (TargetPlayer.GetComponent<PartySystem> ().partymember2 == gameObject) {PlayerXpos = 0;PlayerZpos = -30;}
		//if (TargetPlayer.GetComponent<PartySystem> ().partymember3 == gameObject) {PlayerXpos = 25;PlayerZpos = 30;}
		//if (TargetPlayer.GetComponent<PartySystem> ().partymember4 == gameObject) {PlayerXpos = 25;PlayerZpos = -30;}
		if (Player.GetComponent<PartySystem> ().partymember1 == gameObject) {TargetPlayer = PartySlot1;}
		if (Player.GetComponent<PartySystem> ().partymember2 == gameObject) {TargetPlayer = PartySlot2;}
		if (Player.GetComponent<PartySystem> ().partymember3 == gameObject) {TargetPlayer = PartySlot3;}
		if (Player.GetComponent<PartySystem> ().partymember4 == gameObject) {TargetPlayer = PartySlot4;}

		if (chaseAgainCheck) {
			playerPos = TargetPlayer.transform.position;
			playerPos += new Vector3 (PlayerXpos, 0, PlayerZpos);
		}

		Distance2 = Vector3.Distance(Player.position, transform.position);
		Distance = Vector3.Distance(TargetPlayer.position, transform.position);
		if (chaseBool) {
			CharacterController controller = GetComponent<CharacterController>();
			moveDirection.y -= gravity1 * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
			

			
			if (Distance < lookAtDistance  && chaseAgainCheck == true &&
				GetComponent<CharacterUI>().uiActive == 0)
			{
				lookAt();
			}
			
			if (Distance < attackRange)
			{
				attack();
			}
			if (Distance < chaseRange && Distance > attackRange && chaseAgainCheck == true &&
				GetComponent<CharacterUI>().uiActive == 0)
			{
				chase();
			}



			if (Distance > chaseAgain)
			{
				chaseAgainCheck = true;
			}
			if (Distance < attackRange)
			{
				chaseAgainCheck = false;
			}
		}


	}

	void lookAt ()
	{
		Vector3 targetPostition = new Vector3(TargetPlayer.position.x,this.transform.position.y, TargetPlayer.position.z );
		this.transform.LookAt (targetPostition);
		//Quaternion rotation = Quaternion.LookRotation(TargetPlayer.position - transform.position);
		//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
	}

	void chase ()
	{
		CharacterController controller = GetComponent<CharacterController>();
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * moveSpeed);
	}

	void attack ()
	{
		if (Time.time > attacktime)
		{
			//Player.SendMessage("ApplyDammage", TheDammage);
			Debug.Log("The Enemy Has Attacked");
			attacktime = Time.time + attackRepeatTime;
		}
	}
}
