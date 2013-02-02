using UnityEngine;
using System.Collections;
using SecretSauce;
public class init_level : MonoBehaviour {

	// Use this for initialization
	private Camera cam;
	public PlayerShip ship;
	//TODO:replace with various zoom levels
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		cam = Camera.mainCamera;
		cam.transform.parent = ship.transform; 
	}
}
