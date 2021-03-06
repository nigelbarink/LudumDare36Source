﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class spawnpoint : MonoBehaviour {
	int wave = 0 ;
	int boss = 1 ;
	public GameObject winscreen ;
	public GameObject[] units ;
	public List<GameObject> Enemy; 
	// big time
	float Time = 10; // DEFAULT to 60
	float reset_time = 30;

	//minion time
	float miniontime = 5f;
	float resetminiontime = 5f;

	//TODO: implement a difficulty grade from 0 being easy to 1 being extremly deadly!
	float difficulty; 

	void Update () {
		if ( units == null) {
			Debug.LogError ("there are no machinary found for this team to be instantiated !"); 
			return;
		}
		Time =  Time - 0.01f;
		if (Time <= 1f) {
			miniontime = miniontime - 0.01f;
		}

		//Debug.Log ("time left: " + (int) Time + " Minion Time: " + (int) miniontime);
		if (Time <= 0 && miniontime <= 0) {
			pick_wave ();

		}
	}



	void pick_wave (){

		switch (wave) {
		case 0:
			Debug.Log ("Wave 0");
			spawn_wave (2,0, true);
			break;

		case 1:
			Debug.Log ("Wave 1");
			spawn_wave (2, 0);
			spawn_wave (1, 1, true);
			break;
		case 2:
			Debug.Log ("Wave 2");
			spawn_wave (2, 1);
			spawn_wave (1, 3);
			spawn_wave (1, 2, true);
			break;
		case 3:
			Debug.Log ("Wave 3");
			spawn_wave (1, 1);
			spawn_wave (2, 2 , true);
			break;
		case 4:
			Debug.Log ("Wave 4");
			spawn_wave (2, 2);
			spawn_wave (1, 4, true);
			break;
		case 5:
			Debug.Log ("Wave 5");
			spawn_wave (2, 1);
			spawn_wave (1, 2);
			spawn_wave (1, 3);
			spawn_wave (1, 4);
			spawn_wave (1, 5, true);
			break;

		default:
			wave = 0;
			spawnboss (boss);
			break;
		}

	}

	void spawn_wave (int amt , int TYPE, bool LAST = false ){
		
		if (miniontime <= 0 ) {
				
			Vector3 somevector = transform.position + new Vector3 (Random.Range (-4,-8 ) , 0, 0);
					for (int x = 0; x < amt; x++) {
						Debug.Log ("Spawns enemy minions!");


				GameObject go = (GameObject)GameObject.Instantiate ( units[TYPE] , somevector, Quaternion.identity);
				Enemy.Add (go);
				go.GetComponent<Unit_AI> ().spawn = this.gameObject;
					}
			if (LAST) {
				miniontime = resetminiontime;
			}
			}
			wave++;
			Time = reset_time;



	}





	void spawnboss (int boss ){
		//You win , Since there is no time for a implementation of a boss fight !
		winscreen.SetActive(true);
	}
}
