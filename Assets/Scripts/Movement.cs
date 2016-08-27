using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public int speed = 3;
	public GameObject selected;
	public bool enabled = false;
	public Vector3 cam_pos ;
	Ray ray ;
	RaycastHit2D hit;

	public void Awake (){
		selected = Camera.main.gameObject;
	}
	public void Start (){
		cam_pos = selected.transform.position;
	}

	void Update () {
		//TODO: should we check our input every frame?
		checkselector();

		if (selected == Camera.main.gameObject) {
			Vector3 pos = selected.transform.position;
			float X = Input.GetAxis ("Horizontal") * speed;
			pos += new Vector3 (X ,0,0)  * Time.deltaTime;
			selected.transform.position = pos ;
		}
		if (Input.GetKey (KeyCode.X)) {
			Camera.main.transform.position = cam_pos;
		}
	}
	void checkselector(){
		if (Input.GetKey (KeyCode.Escape)&& enabled) {
			enabled = false;
		}
		if (Input.GetMouseButton (0) && enabled ) {

			ray = Camera.main.ScreenPointToRay (Input.mousePosition);


			hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
			if (hit.collider == null) {
				// the selected point was empty,
				// lets set our selected character to the main Camera.
				Debug.Log ("hit has not been set ! Main Camera was selected");
				selected = Camera.main.gameObject;
				return;
			}
			Debug.Log ("SELECTED: " + hit.collider.name);
			selected = hit.collider.gameObject;
			return;
		}
	}
		public void doAction (){
		// TODO: take action for the selected character ! 
		if (selected == Camera.main.gameObject){
			// we are the camera, we cannot not take action.
			// return immediatly 
			Debug.LogError("camera cannot attack any units, please select a real unit !");
			return;
		}
		Debug.Log (selected.name + " Attack!");

		}

	public void enableSelector(){
		enabled = true;
	}
	public void selectCamera (){
		selected = Camera.main.gameObject;
	}
	
	}
