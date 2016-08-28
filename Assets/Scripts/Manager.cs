using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

	public Text txt;
	public Text tt;
	public GameObject wanr;
	public int credits = 10;
	private int exp = 20;
	int exp_gotten = 10;
	public int experience {
		get{ 
			return exp;
		}
		private set { 
			exp = value;
		}
	}
	public GameObject[] Units;
	float clock = 4;
	int minute = 4;

	public void addCred (int amt ){
		credits += amt;
	}
	public void addExp (){
		exp += exp_gotten;
	}
	public void removeExp (int amt){
		exp -= amt;
	}
	void Start(){

		update_UI_CRED ();
	}
	void Update () {
		clock_cred ();
	}

	void clock_cred(){
		clock = clock -  0.1f;
		//Debug.Log (clock);

		if (clock <= 0) {
			credits++;
			update_UI_CRED();
			clock = minute;
		}
	}

	void update_UI_CRED(){
		if (txt != null && tt != null ){
			txt.text = "Credits: $ " + "<color=green> " + credits.ToString() + "</color>"  ;
			tt.text = "Experience: " + "<color=purple>" + exp.ToString() + "</color>";
		}


	}

	public void buy_Unit (int num ){
		switch (num) {

		case 0:
			if (HasEnough(15)) {
				Buy_Specified (num, 15);
			} 
			break;

		case 1:
			if (HasEnough(20)){
				Buy_Specified (num, 30);
			}

			break;

		case 2:
			if (HasEnough(60)){
				Buy_Specified (num, 60);
			}
			break;
		case 3:
			if (HasEnough(120)){
				Buy_Specified (num, 120);
			}
			break;
		case 4:
			if (HasEnough(210)){
				Buy_Specified (num, 210);
			}
			break;
		case 5:
			if (HasEnough(300)){
				Buy_Specified (num, 300);
			}
			break;

		
		}
	}
	public void buy_Upgrade (int num ){
		List<GameObject> go = Camera.main.gameObject.GetComponent<Movement> ().selected;
		if (go.Contains (Camera.main.gameObject)){
			return;
		}
		Unit selected = go [0].GetComponent<Unit> ();
		switch (num) {

		case 0:
			if (HasEnough(20)){
				selected.health += 10;
			}
			break;

		case 1:
			if (HasEnough(40)){
				selected.power += 2;
			}
			break;

		case 2:
			if (HasEnough(60)){
				//more money per turn 
				selected.credperturn += 2;
			}
			break;
		case 3:
			if (HasEnough(30)){
				// more exp per kill
				exp_gotten += 2;
			}
			break;
		case 4:
			if (HasEnough(100)){
				// heal castle 
			}
			break;
		case 5:
			if (HasEnough(0)){
				Destroy (selected.gameObject);
			}
			break;

		
		}
	}
	void Buy_Specified (int num , int amt ){
			credits -= amt;
		Vector3 somevector = new Vector3 ((int)Random.Range(1,5) ,0,0) + this.transform.position ;
		GameObject.Instantiate (Units [num], somevector, Quaternion.identity);


	}

	public void doAction (int what){
		// TODO: take action for the selected character ! 
		if (Camera.main.GetComponent<Movement>().selected.Contains ( Camera.main.gameObject)){
			// we are the camera, we cannot not take action.
			// return immediatly 
			Debug.LogError("camera cannot attack any units, please select a real unit !");
			return;
		}
		GameObject[] selects = Camera.main.GetComponent<Movement> ().selected.ToArray ();
		foreach (GameObject select in selects) {
			Unit  u = select.GetComponent<Unit> ();
			if (u == null) {
				Debug.LogError ("Unit is not Active!");
			}
			switch (what) {
		
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

	
	}

	public bool HasEnough (int cost ){
		if (credits < cost) {
			wanr.SetActive (true);
			return false;
		} else {
			return true;
		}
	}


}
