using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour {

	public Text txt;
	public int credits = 0;
	public GameObject[] Units;
	float clock = 4;
	int minute = 4;
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
		if (txt != null ){
			txt.text = "Credits: $ " + "<color=green> " + credits.ToString() + "</color>"  ;
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
		GameObject go = (GameObject)GameObject.Instantiate (Units [num], new Vector3 (0,0,0), Quaternion.identity);
		Unit u = go.GetComponent<Unit> ();
		u.amt = 37 * num + 1 ^ 5 / (num * 2 + 1);
		u.power = 50 * num + 1;
		u.health = 100 * num + 100;

	}

}
