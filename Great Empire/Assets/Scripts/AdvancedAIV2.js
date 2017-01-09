//IMPORTANT NOTE! THIS SCRIPT WAS MADE IN VIDEO NUMBER 21! CHECK OUT THE EARLIER VERSION (NOT V2) IF YOU HAVEN'T REACHED THAT VIDEO.

var Distance = 0;
var Target : Transform;
var lookAtDistance = 25.0;
var chaseRange = 15.0;
var attackRange = 1.5;
var moveSpeed = 5.0;
var Damping = 6.0;
var attackRepeatTime = 1;

var chaseBool : boolean = false;

var gravity1 : float = 20.0;

private var moveDirection : Vector3 = Vector3.zero;

var TheDammage = 40;

private var attackTime : float;



function Start ()
{
	attackTime = Time.time;
}

function Update ()
{
    var controller : CharacterController = GetComponent.<CharacterController>();
    moveDirection.y -= gravity1 * Time.deltaTime;
    controller.Move(moveDirection * Time.deltaTime);
	
		Distance = Vector3.Distance(Target.position, transform.position);
		
		if (Distance < lookAtDistance)
		{
			lookAt();
		}
		
		if (Distance < attackRange)
		{
			attack();
		}
		if (Distance < chaseRange && Distance > attackRange)
		{
		    chase();
		}

	
}

function lookAt ()
{
	var rotation =  Quaternion.LookRotation(Vector3(Target.position.x, transform.position.y, Target.position.z) - transform.position);
	transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
}

function chase ()
{
    var controller : CharacterController = GetComponent.<CharacterController>();
	var forward : Vector3 = transform.TransformDirection(Vector3.forward);
	controller.SimpleMove(forward * moveSpeed);
}

function attack ()
{
	if (Time.time > attackTime)
	{
		Target.SendMessage("ApplyDammage", TheDammage);
		Debug.Log("The Enemy Has Attacked");
		attackTime = Time.time + attackRepeatTime;
	}
}
