using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healthbar : MonoBehaviour {
	public GameObject HealthBar;

	public void Start(){
		HealthBar = (GameObject)Instantiate (HealthBar, transform.position, Quaternion.identity);
		HealthBar.transform.SetParent ( this.gameObject.transform);
	}
 public void set_max_value (int max_health ){
		HealthBar.GetComponent<Slider> ().maxValue = max_health;
	}

	public void update_health (int health) {
		HealthBar.GetComponentInChildren<Slider> ().value = health;
	}
}
