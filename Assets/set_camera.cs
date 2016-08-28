using UnityEngine;
using System.Collections;

public class set_camera : MonoBehaviour {

	void Start () {
		GetComponent<Canvas> ().renderMode = RenderMode.WorldSpace ;
		GetComponent<Canvas> ().worldCamera = Camera.main;
		if (gameObject.transform.parent.tag == "Enemy") {
			transform.localScale = new Vector3 (0.1f, 0.1f, 0f);
		} else {
			transform.localScale = new Vector3 (0.03f, 0.03f, 0f);

		}

		transform.position = this.transform.parent.transform.position +  new Vector3 (0,1.5f,0);

	}

}
