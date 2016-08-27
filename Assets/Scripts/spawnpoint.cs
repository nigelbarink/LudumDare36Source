using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnpoint : MonoBehaviour {
	int wave = 0 ;
	int boss = 1 ;

	// big time
	float Time = 4; // DEFAULT to 60
	float reset_time = 30;

	//minion time
	float miniontime = 5f;
	float resetminiontime = 5f;

	int perUnits = 0;
	//TODO: implement a difficulty grade from 0 being easy to 1 being extremly deadly!
	float difficulty; 


	public GameObject[] Machinary;

	void Update () {
		if (Machinary == null) {
			Debug.LogError ("there are no machinary found for this team to be instantiated !"); 
			return;
		}

		Time =  Time - 0.01f;
		if (Time <= 1f) {
			miniontime = miniontime - 0.01f;
		}

		Debug.Log ("time left: " + (int) Time + " Minion Time: " + (int) miniontime);
		if (Time <= 0 ) {
			pick_wave ();

		}
	}



	void pick_wave (){

		switch (wave) {
		case 0:
			Debug.Log ("Wave 0");
			spawn_wave (5, 2);
			break;

		case 1:
			Debug.Log ("Wave 1");
			spawn_wave (5, 2);
			break;
		case 2:
			Debug.Log ("Wave 2");
			spawn_wave (5, 2);
			break;
		case 3:
			Debug.Log ("Wave 3");
			spawn_wave (5, 2);
			break;
		case 4:
			Debug.Log ("Wave 4");
			spawn_wave (5, 2);
			break;
		case 5:
			Debug.Log ("Wave 5");
			spawn_wave (5, 2);
			break;

		default:
			wave = 0;
			spawnboss (boss);
			break;
		}

	}

	void spawn_wave (int amt , int groups){
		if (miniontime <= 0 && perUnits < groups) {
			for (int y = 0; y < groups; y++) {

				if (miniontime <= 0) {
					for (int x = 0; x < amt; x++) {
						Debug.Log ("Spawns enemy minions!");
						Vector3 somevector = transform.position + new Vector3 (Random.Range (-8, -16), 0, 0);
						GameObject go = (GameObject)GameObject.Instantiate (Machinary [0], somevector, Quaternion.identity);
						go.name = go.name + "_" + x;
					}

					miniontime = resetminiontime;
				}
			

			}
			wave++;
			Time = reset_time;
		}


	}





	void spawnboss (int boss ){
		Debug.Log ("spawns boss!");
		Time = reset_time;
		boss++;
	}
}
