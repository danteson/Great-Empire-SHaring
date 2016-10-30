using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
	
	public float Distance = 0f;
	public Transform TargetPlayer;
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
		if (TargetPlayer.GetComponent<PartySystem> ().partymember1 == gameObject) {PlayerXpos = 0;PlayerZpos = 30;}
		if (TargetPlayer.GetComponent<PartySystem> ().partymember2 == gameObject) {PlayerXpos = 0;PlayerZpos = -30;}
		if (TargetPlayer.GetComponent<PartySystem> ().partymember3 == gameObject) {PlayerXpos = 25;PlayerZpos = 30;}
		if (TargetPlayer.GetComponent<PartySystem> ().partymember4 == gameObject) {PlayerXpos = 25;PlayerZpos = -30;}


		if (chaseAgainCheck) {
			playerPos = TargetPlayer.transform.position;
			playerPos += new Vector3 (PlayerXpos, 0, PlayerZpos);
		}


		Distance = Vector3.Distance(TargetPlayer.position, transform.position);
		if (chaseBool) {
			CharacterController controller = GetComponent<CharacterController>();
			moveDirection.y -= gravity1 * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
			

			
			if (Distance < lookAtDistance  && chaseAgainCheck == true)
			{
				lookAt();
			}
			
			if (Distance < attackRange)
			{
				attack();
			}
			if (Distance < chaseRange && Distance > attackRange && chaseAgainCheck == true)
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

		if (Distance > chaseAgain) {
			if (bolean) {
				GetComponent<CharacterUI> ().uiActive = 0;
				GetComponent<CharacterUI> ().talkCount = 0;
				TargetPlayer.GetComponent<PlayerController> ().toggleOrbit = 0;
				bolean = false;
			}
		} else {
			bolean = true;
		}
	}

	void lookAt ()
	{
		Quaternion rotation = Quaternion.LookRotation(playerPos - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
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
			TargetPlayer.SendMessage("ApplyDammage", TheDammage);
			Debug.Log("The Enemy Has Attacked");
			attacktime = Time.time + attackRepeatTime;
		}
	}
}
