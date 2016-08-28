using UnityEngine;
using System.Collections;

public class scroll_me : MonoBehaviour {
	
	void Update () {
		Vector3 h = Camera.main.transform.position;
		transform.position = new Vector3 (h.x , h.y , 0) ;
	}
}
