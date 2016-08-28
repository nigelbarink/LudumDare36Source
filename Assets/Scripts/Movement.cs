using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
	public int speed = 3;
	public List<GameObject> selected;
	public bool M_enabled = false;
	public Vector3 cam_pos ;
	public Text warning ;
	Ray ray ;
	RaycastHit2D hit;


	public void Awake (){
		selected.Add (Camera.main.gameObject);
	}
	public void Start (){
		cam_pos = selected[0].transform.position;
	}

	void Update () {
		//TODO: should we check our input every frame?
		checkselector();


				
			/*
			float posc = selected.transform.position.x;
			Camera.main.transform.position = new Vector3 (posc,Camera.main.transform.position.y,Camera.main.transform.position.z) ;
			*/
		 


		if (selected.Contains (Camera.main.gameObject)) {
			Vector3 pos = selected[0].transform.position;
			float X = Input.GetAxis ("Horizontal") * speed;
			pos += new Vector3 (X ,0,0)  * Time.deltaTime;
			selected[0].transform.position = pos ;
		}
		if (Input.GetKey (KeyCode.X)) {
			Camera.main.transform.position = cam_pos;
		}

		if (Input.GetKey (KeyCode.W)) {
			if (selected.Count == null) {
				Debug.LogError ("contains no units !");
				return;
			}
			foreach (GameObject select in selected) {
				select.GetComponent<Unit> ().move ();
			}
		}
		if (Input.GetKey (KeyCode.S)) {
			foreach (GameObject select in selected) {
				select.GetComponent<Unit> ().fallback ();
			}
		}
		if (Input.GetKey (KeyCode.C)) {
			if (! selected.Contains ( Camera.main.gameObject)) {
				selectCamera ();
			} else {
				M_enabled = true;
			}
		}
	}
	void checkselector(){
		if (M_enabled){
			if (Input.GetMouseButton (1)) {
				M_enabled = false;
				warning.gameObject.SetActive ( false);
				return;
			}
		if (Input.GetMouseButton (0)) {

			ray = Camera.main.ScreenPointToRay (Input.mousePosition);


			hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
				if (hit.collider == null ) {
				// the selected point was empty,
					// lets set our selected character to the main Camera.
				
				Debug.Log ("hit has not been set ! Main Camera was selected");
				//selected = Camera.main.gameObject;
			
				if (selected.Count > 0) {
					selected.Clear ();
				}
				selected.Add(Camera.main.gameObject);
					foreach (GameObject select in selected) {
						Debug.Log (select.gameObject.name);
					}	
				return;
				}else if (hit.collider != null && hit.collider.tag == "Player" && hit.collider.gameObject.tag != "Castle" && !selected.Contains (hit.collider.gameObject)){
					if (selected.Contains (Camera.main.gameObject)) {
						selected.Remove (Camera.main.gameObject);
					}
					Debug.Log ("SELECTED: " + hit.collider.name);

					selected.Add(hit.collider.gameObject);
				
					if (! selected.Contains ( Camera.main.gameObject)) {
					
						foreach (GameObject	select in selected) {
							select.GetComponentInChildren<SpriteRenderer> ().color = Color.red;
						}
					}
				} 
				else { Debug.Log ("Error !!!"); return;}
			}

				if (Input.GetKey (KeyCode.Escape)) {
					M_enabled = false;
				warning.gameObject.SetActive( false);
					foreach (GameObject select in selected) {
						SpriteRenderer rend = select.GetComponent<SpriteRenderer> ();
						if (rend) {
							rend.color = Color.white;
						}
					}

				}

		}
	}
	public void enableSelector(){
		M_enabled = true;
	}
	public void selectCamera (){
		foreach (GameObject select in selected) {
			SpriteRenderer rend = select.GetComponent<SpriteRenderer> ();
			if (rend) {
				rend.color = Color.white;
			}
		}

		//selected = Camera.main.gameObject;
		if (selected.Count > 0 ){
			selected.Clear ();
		}
		selected.Add (Camera.main.gameObject);
	}
	
	}
