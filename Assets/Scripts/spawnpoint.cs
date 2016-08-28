using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnpoint : MonoBehaviour {
	int wave = 0 ;
	int boss = 1 ;

	public GameObject[] units ;

	// big time
	float Time = 4; // DEFAULT to 60
	float reset_time = 30;

	//minion time
	float miniontime = 5f;
	float resetminiontime = 5f;

	int perUnits = 0;
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
				
					Vector3 somevector = transform.position + new Vector3 (-1, 0, 0);
					for (int x = 0; x < amt; x++) {
						Debug.Log ("Spawns enemy minions!");


				GameObject.Instantiate ( units[0] , somevector, Quaternion.identity);

					}

					miniontime = resetminiontime;
			}
			wave++;
			Time = reset_time;



	}





	void spawnboss (int boss ){
		//Debug.Log ("spawns boss!");
		Time = reset_time;
		boss++;
	}
}
