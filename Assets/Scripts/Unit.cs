using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	public int Unit_type = 0; 
	public int amt ;
	public float health;
	public float power;
	public float range = 8 ;
	bool moving = false ;

	public void Update(){
		if (moving) {
			transform.position += new Vector3 (amt, 0, 0) * Time.deltaTime;
		}


		}


	public void move (){
		if (amt < 0) {
			amt = -amt;
		}
		moving = true;
	}
	public void attack (){
		// find player within a certain range !
		Collider2D [] others = Physics2D.OverlapCircleAll (transform.position + new Vector3 (0,0,1) ,range , this.gameObject.layer);
		Debug.Log (others.Length.ToString());
		if (others.Length > 0) {
			foreach (Collider2D m in others){
				Debug.Log ("Attack!");
				m.GetComponent<Unit> ().health -= power / (others.Length - 8);
			}
		}else{
			Debug.Log ("no Enemies near!");
		}
	}
	public void fallback (){
		amt = -amt;
		if (!moving) {
			move ();
		}
	}


	public void OnTriggerEnter2D (Collider2D other ){
		if (other.gameObject.name != "ground") {
			moving = false;
			attack ();
		} else {
			return;
		}
	}

}
