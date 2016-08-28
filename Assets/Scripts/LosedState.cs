using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LosedState : MonoBehaviour {
	public GameObject losed;
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			losed.SetActive (true);
		}
	}

	public void LoadNext(string s){
		SceneManager.LoadScene (s);
	}
	public void showSite(){
		Application.OpenURL ("http://www.haveaniceday.net84.net");
	}
	public void Terminate (){
		Application.Quit ();
	}
}
