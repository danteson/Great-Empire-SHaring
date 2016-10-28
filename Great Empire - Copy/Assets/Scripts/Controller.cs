using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	private CharacterController character;
	public GameObject CharCamera;

	public bool SwordOn = false;
	public GameObject SwordGreatnessOff;
	public GameObject SwordGreatnessOn;
	
	public bool FlyMode = false;
	public bool walking = false;
	
	public int toggleOrbit = 0;
	
	public GameObject camOffset;

	int AttackNr = 1;
	public bool stun = false;

	Animator anim;
	
	void Start () {
		character = GetComponent<CharacterController>();


		anim = GetComponent<Animator> ();
		
		speed=10;
		flySpeed=20;
		jumpSpeed = 20;
		offFlight = 40;
		riseUp = -600;
		goDown = 600;
	}
	
	public float offFlight;
	public float flySpeed;
	public float speed;
	public float jumpSpeed;
	public float gravity;
	public float riseUp;
	public float goDown;
	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded && stun == false) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetKeyDown("space"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		AttackNr += 1;
		if (AttackNr == 11) {
			AttackNr = 1;
		}

		if (Input.GetMouseButtonDown  (0) && stun == false && SwordOn == false) {

			if (AttackNr == 1 && walking == false) {
				anim.SetBool("Punch1", true);
		}
			if (AttackNr == 3 && walking == false) {
				anim.SetBool("Punch2", true);
			}

			if (AttackNr == 5 && walking == false) {
				anim.SetBool("Punch3", true);
			}

			if (AttackNr == 7 && walking == false) {
				anim.SetBool("Punch4", true);
			}

			if (AttackNr == 9 && walking == false) {
				anim.SetBool("Punch5", true);
			}
			if (AttackNr == 2 && walking == false) {
				anim.SetBool("Kick1", true);
			}
			if (AttackNr == 4 && walking == false) {
				anim.SetBool("Kick2", true);
			}

			if (AttackNr == 6 && walking == false) {
				anim.SetBool("Kick3", true);
			}

			if (AttackNr == 8 && walking == false) {
				anim.SetBool("Kick4", true);
			}

			if (AttackNr == 10 && walking == false) {
				anim.SetBool("Kick5", true);
			}

		}
		//		SwordGreatnessOff.GetComponent<RabbitScript>().BunnyHP
		if (Input.GetKeyDown ("e") && stun == false && SwordOn == false) {
			SwordGreatnessOff.SetActive (false);
			SwordGreatnessOn.SetActive (true);
			SwordOn = true;
			anim.SetBool("IdleSword", true);
			anim.SetBool("Idle", false);
		}

		if (Input.GetKeyDown ("q") && stun == false && SwordOn == true) {
			SwordGreatnessOff.SetActive (true);
			SwordGreatnessOn.SetActive (false);
			SwordOn = false;
			anim.SetBool("IdleSword", false);
			anim.SetBool("Idle", true);
		}
			


		if (Input.GetMouseButtonUp  (0)) {
			anim.SetBool("Punch1", false);
			anim.SetBool("Punch2", false);
			anim.SetBool("Punch3", false);
			anim.SetBool("Punch4", false);
			anim.SetBool("Punch5", false);
			anim.SetBool("Kick1", false);
			anim.SetBool("Kick2", false);
			anim.SetBool("Kick3", false);
			anim.SetBool("Kick4", false);
			anim.SetBool("Kick5", false);
		}

		if (Input.GetKey ("c") && controller.isGrounded) {
			stun = true;
			anim.SetBool("Bow", true);
		}
		else
		{
			stun = false;
			anim.SetBool("Bow", false);
		}
		#region walking
		if (Input.GetKey ("w")) {
			walking = true;
			anim.SetBool("Walk", true);
		}
		else {
			anim.SetBool("Walk", false);
			walking = false;
		}

		if (Input.GetKey ("s")) {
			walking = true;
			anim.SetBool("WalkBack", true);
		}
		else {
			anim.SetBool("WalkBack", false);
			walking = false;
		}

		#endregion


		if (Input.GetKeyDown ("1")) {
			speed=3;
			flySpeed=3;
			jumpSpeed = 3;
			offFlight = 6;
			riseUp = -50;
			goDown = 50;
		}
		if (Input.GetKeyDown ("2")) {
			speed=10;
			flySpeed=10;
			jumpSpeed = 10;
			offFlight = 20;
			riseUp = -600;
			goDown = 600;
		}
		
		if (Input.GetKeyDown ("3")) {
			speed=50;
			flySpeed=50;
			jumpSpeed = 50;
			offFlight = 100;
			riseUp = -3000;
			goDown = 3000;
		}
		
		if (Input.GetKeyDown ("4")) {
			speed=120;
			flySpeed=120;
			jumpSpeed = 120;
			offFlight = 240;
			riseUp = -7200;
			goDown = 7200;
		}
		
		if (Input.GetKeyDown ("5")) {
			speed=250;
			flySpeed=250;
			jumpSpeed = 250;
			offFlight = 500;
			riseUp = -15000;
			goDown = 15000;
		}
		if (Input.GetKeyDown ("6")) {
			speed=1500;
			flySpeed=1500;
			jumpSpeed = 1500;
			offFlight = 3000;
			riseUp = -80000;
			goDown = 80000;
		}
		
		if (FlyMode == false){
			gravity = offFlight;
		}
		else {
			gravity = gravity;
		}
		
		
		#region Flying Section
		//Movement in air
		if (FlyMode == true) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= flySpeed;
		}
		//Turn fly mode on and make gravity 0
		if (Input.GetKeyDown ("r") && FlyMode == false) {
			FlyMode = true;
			gravity = 0;
			//Turn fly mode off and make default gravity
		} else if (Input.GetKeyDown ("r") && FlyMode == true) {
			FlyMode = false;
			StopCoroutine("FloatUp");
			gravity = 20;
		}
		//Start float
		if (Input.GetKeyDown ("space") && FlyMode == true) {
			Flying();
		}
		//Add height
		if (Input.GetKey ("space") && FlyMode == true) {
			gravity = riseUp;
		}
		//Reduce height
		if (Input.GetKey ("f") && FlyMode == true){
			gravity = goDown;
		}
		if (Input.GetKeyUp ("f") && FlyMode == true){
			StartCoroutine (StopFloat (0.5f));
			gravity = 0;
		}
		
		
		//Stop adding height
		
		if (Input.GetKeyUp ("space") && FlyMode == true) {
			StartCoroutine (StopFloat (0.5f));
			gravity = 0;
		}
		
		
		if (Input.GetKeyDown("escape")) {
			toggleOrbit += 1;
		}
		
		if (toggleOrbit == 2) {
			toggleOrbit = 0;
		}
		
		if (toggleOrbit == 1) {
			GetComponent<SmoothLookAt>().enabled = false;
			camOffset.GetComponent<SmoothLookAt>().enabled = false;
		}

		if (toggleOrbit == 0) {
			GetComponent<SmoothLookAt>().enabled = true;
			camOffset.GetComponent<SmoothLookAt>().enabled = true;
		}
	}
	
	void Flying() {
		StartCoroutine (FloatUp (0.0f));
	}
	
	
	IEnumerator FloatUp (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		if (FlyMode)
			gravity = -150;
		StartCoroutine (StopFloat (0.5f));
	}
	
	IEnumerator StopFloat (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		if (FlyMode)
			gravity = 5;
		StartCoroutine (Float (0.1f));
	}
	
	IEnumerator Float (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		if (FlyMode)
			gravity = 0;
	}
	#endregion
	void ZoomBackIn() {
		Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,60,2f * Time.deltaTime);
	}
}
