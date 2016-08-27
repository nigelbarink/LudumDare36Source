using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movement : MonoBehaviour {
	public int speed = 3;
	public GameObject selected;
	public bool enabled = false;
	public Vector3 cam_pos ;
	public Text warning ;
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

		if (selected != Camera.main.gameObject) {
			float posc = selected.transform.position.x;
			Camera.main.transform.position = new Vector3 (posc,Camera.main.transform.position.y,Camera.main.transform.position.z) ;
		}


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
			warning.enabled = false;
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
			enabled = false;
			warning.enabled = false;
			return;
		}
	}
	public void doAction (int what){
		// TODO: take action for the selected character ! 
		if (selected == Camera.main.gameObject){
			// we are the camera, we cannot not take action.
			// return immediatly 
			Debug.LogError("camera cannot attack any units, please select a real unit !");
			return;
		}

		Unit  u = selected.GetComponent<Unit> ();

		switch (what) {

		case 0:
			u.attack ();
			break;
		
		case 1:
			u.move ();
			break;
		
		case 2:
			u.fallback ();
			break;

		default:
			Debug.LogError ("This action doesnt excist yet!");
			break;
		}

		}

	public void enableSelector(){
		enabled = true;
	}
	public void selectCamera (){
		selected = Camera.main.gameObject;
	}
	
	}
