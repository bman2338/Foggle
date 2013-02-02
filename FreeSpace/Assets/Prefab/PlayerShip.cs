using UnityEngine;
using System.Collections;
using SecretSauce;
public class PlayerShip : MonoBehaviour {
	
	Mesh shipMesh {get;set;}
	public GameObject hoverPlate;
	// Use this for initialization
	
	//transform.TransformDirection(normalFromMesh)
	void Start () {
		
		
		
		
	}
	
// This script uses the left and right arrow keys for steering, and the 
// up and down arrow keys for forward and backward movement. The rotation
// and movement rates are specified below.
float rotateSpeed = 90.0f;
float speed = 1.0f;
 
	void Update () {
	
		RaycastHit hitinfo;
		if(Physics.Raycast(transform.position,-transform.forward,out hitinfo)){
			transform.rigidbody.AddForce(-hitinfo.normal * 100);
			//transform.rotation = Quaternion.LookRotation(-transform.up, -hitinfo.normal);
			transform.forward = hitinfo.normal;
			//transform.rotation = hitRotation;
		}
		
	
		
	/**
		foreach(var norm in norms){
			Debug.Log ("Normal:" + i + " " + norm);	
			i++;
		}
	**/	
		
	
		
	 	
		/** curves it downwards
		var movement = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate(0, 0, movement);
		*/
		
	    var transAmount = speed * Time.deltaTime;
		var rotateAmount = rotateSpeed * Time.deltaTime;
	 
	    if (Input.GetKey("up")) {
			transform.Translate(0, transAmount, 0);
		}
		if (Input.GetKey("down")) {
			transform.Translate(0, -transAmount, 0);
		}
		if (Input.GetKey("left")) {
			transform.Translate(transAmount,0,0);
		}
		if (Input.GetKey("right")) {
			transform.Translate(-transAmount,0,0);
		}
	}
}
