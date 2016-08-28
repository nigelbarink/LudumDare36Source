using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour {

	public Text txt;
	public Text tt;
	int credits = 10;
	int exp = 0;
	public GameObject[] Units;
	float clock = 4;
	int minute = 4;

	public void addCred (int amt ){
		credits += amt;
	}
	public void addExp (int amt ){
		exp += amt;
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
			if (credits >= 15f){
				Buy_Specified (num, 15);
			}
			break;

		case 1:
			if (credits >= 30f){
				Buy_Specified (num, 30);
			}
			break;

		default:
			Debug.Log ("The Unit Asked does not excist");
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

	
	}

}
