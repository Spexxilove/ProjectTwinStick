using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	void OnDestroy(){
		WaveGenerator wGenerator =  GameObject.FindGameObjectWithTag ("GameController").GetComponent<WaveGenerator>();
		wGenerator.enemyKilled ();
	}
}
