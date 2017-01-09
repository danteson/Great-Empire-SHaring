//****** Donations are greatly appreciated.  ******
//****** You can donate directly to Jesse through paypal at  https://www.paypal.me/JEtzler   ******

var target : Transform; 
var moveSpeed = 20; 
var rotationSpeed = 5; 
var myTransform : Transform; 

function Awake() {
	myTransform = transform; 
}

function Start() {

	target = GameObject.FindWithTag("Player").transform; 
}

function Update () {
   
    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
    Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime); 
    myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
}