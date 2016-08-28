using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonHandler : MonoBehaviour {

	public GameObject[] Shop ;
	public GameObject[] upgds ;
	Manager man ;
//	int clock = 0;
//	int reset = 5 ;
	public void Start (){
		man = GameObject.Find ("Manager").GetComponent<Manager> ();
	}

	void Update  () {
//		clock--;
		//Debug.Log (clock.ToString ());

			Update_buttons ();
			Update_upbuttons ();
			

	}
	void Update_buttons (){

		if (Shop == null) {
			Debug.LogError ("Array is null!");
			return;
		}
		for (int x = 0; x < Shop.Length; x++) {
			if (  man.credits >= Shop [x].GetComponent<Cost> ().cost && Shop [x].GetComponent<Button> ().interactable == false) {
				Shop [x].GetComponent<Button> ().interactable = true;
			}
		}

	}

	void Update_upbuttons(){
		if (upgds == null) {
			Debug.LogError ("Array is null!");
			return;
		}
		for (int x = 0; x < Shop.Length; x++) {
			if (upgds [x].GetComponent<Button> ().interactable == false && man.credits >= upgds [x].GetComponent<Cost> ().cost) {
				upgds [x].GetComponent<Button> ().interactable = true;
			} 
		}
	

	
	}


}
