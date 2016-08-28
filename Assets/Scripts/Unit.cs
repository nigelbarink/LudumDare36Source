using UnityEngine;
using System.Collections;
[RequireComponent (typeof(healthbar))]
public class Unit : MonoBehaviour {

	public int amt = 2;
	public int credperturn = 1 ;
	public float health;
	public float power;
	public float range = 8 ;
	public bool moving = false ;
	Manager manage;
	public void Start (){
		manage = GameObject.Find ("Manager").GetComponent<Manager> ();
	}
	public void Update(){
		if (moving) {
			Vector3 pos =	transform.position;
			pos += new Vector3 (amt, 0, 0) * Time.deltaTime;
			transform.position = pos;
		}
		Collider2D [] others = Physics2D.OverlapCircleAll (transform.position + new Vector3 (0,0,1) ,range , 1 << LayerMask.NameToLayer("Player"));
		Collider2D [] otherss = Physics2D.OverlapCircleAll (transform.position + new Vector3 (0,0,1) ,range , 1 << LayerMask.NameToLayer("Enemy"));
//		Debug.Log (others.Length + " " + otherss.Length);
		if (others.Length > 0 || otherss.Length > 0) {
			if (otherss.Length > 0) {
				if (moving) {
					moving = false;
				}
				attack (otherss);
			} else if (others.Length > 0) {

				return;
			}
		}

		manage.addCred (credperturn);
	
		if (health <= 0) {
			Movement m = Camera.main.GetComponent<Movement> ();
			if (m.selected.Contains(this.gameObject)){
				m.selected.Remove (this.gameObject);
			} 
			manage.removeExp (10);
			Destroy (this.gameObject);

		}

		healthbar gui = GetComponent<healthbar> ();
		if (gui != null) {
			gui.update_health ((int)health);
		}
	}


	public void move (){
		moving = true;
	}
	public void attack (){
		// find player within a certain range !
		Collider2D [] others = Physics2D.OverlapCircleAll (transform.position + new Vector3 (0,0,1) ,range , 1 << LayerMask.NameToLayer("Enemy"));
//		Debug.Log (others.Length.ToString());
		if  (others.Length > 0) {
			foreach (Collider2D m in others){
				Debug.Log ("Attack!");
				m.GetComponent<Unit> ().health -= power  ;
			}
		}
		if (others.Length > 0) {
			attack ();
		}
		Debug.Log ("no Enemies near!");

	}
	public void attack (Collider2D[] Units){
		foreach (Collider2D col in Units) {
			Unit_AI u = col.gameObject.GetComponent<Unit_AI> ();
			if (u == null) {
				Debug.Log ("Unit is null");
				return;
			}
			u.health -= power;
			//			u.fallback ();
		}}

	public void fallback (){
		amt = -amt;
		if (!moving) {
			move ();
		}
	}







}