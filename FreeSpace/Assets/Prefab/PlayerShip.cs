using UnityEngine;
using System.Collections;
using SecretSauce;
public class PlayerShip : MonoBehaviour {
	
	Mesh shipMesh {get;set;}
	// Use this for initialization
	//Pipe width = roughly 3.5
	private GameObject pipe;
	
	//for the second ray trace to find the spine of the track
	private Vector3 NO_HIT = new Vector3(999999,999999,999999);
	private float SEARCH_INC = .1f;
	//transform.TransformDirection(normalFromMesh)
	void Start () {
		
		
		
		
	}
	
// This script uses the left and right arrow keys for steering, and the 
// up and down arrow keys for forward and backward movement. The rotation
// and movement rates are specified below.
float rotateSpeed = 3.0f;
float speed = 11.0f;
 
	void Update () {
	
		RaycastHit hitinfo;
		Vector3 hitPoint = NO_HIT;
		if(Physics.Raycast(transform.position,-transform.forward,out hitinfo)){
			if(hitinfo.distance >=.01){
				transform.rigidbody.AddForce(-hitinfo.normal * 10);
				transform.forward = hitinfo.normal;
			}
			hitPoint = hitinfo.point;
		}
		Vector3 pipeToShipDir = hitinfo.normal;
		
	 	// get the other side of the pipe
		Vector3 center = Vector3.zero;
		
		//Raycast through the objec to the other side
		//then raycast downward to the opposite face
		
		//we have hit... use a better val
		if(hitPoint.x != NO_HIT.x){
			
			Vector3 lastSearchOrigin
				= hitPoint - hitinfo.normal ;
			
			for(float SEARCH_INC = 3f;
				SEARCH_INC<= 10.0f;
				SEARCH_INC+=1f){
					Ray searchRay = new Ray(lastSearchOrigin,pipeToShipDir);
					searchRay.direction = pipeToShipDir;
					searchRay.origin = lastSearchOrigin;
					
					RaycastHit hitinfo2;
					
					Debug.Log ("Search:" + searchRay);
					if(Physics.Raycast(searchRay,out hitinfo2,SEARCH_INC)){
						center = (hitinfo2.point - hitPoint) / 2.0f;
						var centerX = transform.TransformPoint(center);
						Debug.Log ("Center:" + centerX);
						break;
				}
			}
		}
	    var transAmount = speed * Time.deltaTime;
		var rotateAmount = rotateSpeed * Time.deltaTime;
	 
	    if (Input.GetKey("up")) {
			transform.Translate(0, transAmount, 0);
		}
		if (Input.GetKey("down")) {
			transform.Translate(0, -transAmount, 0);
		}
		
		//doesn't fucking work obviously
		if (Input.GetKey("left")) {
			
		}
		if (Input.GetKey("right")) {
			
		}
		//strafe
		if(Input.GetKey ("a")){
			//transform.RotateAround(new Vector3());	
		}
		if(Input.GetKey ("d")){
			//transform.RotateAround(new Vector3());	
		}
	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject == pipe){
			return;	
		}
	}
}
