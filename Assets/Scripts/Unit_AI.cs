using UnityEngine;
using System.Collections;
[RequireComponent (typeof(healthbar))]
public class Unit_AI : MonoBehaviour {
	public int amt = 8;
	public float health;
	public float power;
	public float range = 8 ;


	public void Update(){
		Collider2D [] others = Physics2D.OverlapCircleAll (transform.position + new Vector3 (0,0,1) ,range , 1 << LayerMask.NameToLayer("Player"));
		Collider2D [] otherss = Physics2D.OverlapCircleAll (transform.position + new Vector3 (0,0,1) ,range , 1 << LayerMask.NameToLayer("Enemy"));
		//Debug.Log (others.Length.ToString () + " , " + otherss.Length.ToString ());
		if  (others.Length <= 0 && otherss.Length <= 0 ) {
			transform.position += new Vector3 (-amt, 0, 0) * Time.deltaTime;
		}
		else if (others.Length > 0 || otherss.Length > 0 ){
			if (others.Length > 0) {
				attack (others);
			} else if (otherss.Length > 0) {
				foreach(Collider2D anom in otherss ){
					if (anom.gameObject == this.gameObject) {
						transform.position += new Vector3 (-amt, 0, 0) * Time.deltaTime;
						return;
					}
				}
				return;
			} else {
				transform.position += new Vector3 (-amt, 0, 0) * Time.deltaTime;
			
				return;	
			}

		
			}

		if (health <= 0) {
			GameObject.Find ("Manager").GetComponent<Manager> ().addExp ();
			Destroy (this.gameObject);
		}

		healthbar gui = GetComponent<healthbar> ();
		if (gui != null) {
			gui.update_health ((int)health);
		}
	}


				public void attack (Collider2D[] Units){
		foreach (Collider2D col in Units) {
			Unit u = col.gameObject.GetComponent<Unit> ();
			if (u == null) {
				return;
			}
			u.health -= power;
//			u.fallback ();
		}
				
				}

}
