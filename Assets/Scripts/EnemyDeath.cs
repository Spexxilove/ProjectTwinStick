using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	public void onEnemyDeath(){
		
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 1) {
			WaveGenerator wGenerator = GameObject.FindGameObjectWithTag ("GameController").GetComponent<WaveGenerator> ();
			wGenerator.enemiesKilled ();
		}
	}
}
