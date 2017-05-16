using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

	private int wavenumber = 0;

	[SerializeField]
	private float minDistanceFromCenter = 3.0f;

	[SerializeField]
	private float maxDistanceFromCenter = 12.0f;


	[SerializeField]
	private GameObject[] spawnableEnemies;

	[SerializeField]
	private GameObject waveTrigger;


	// Use this for initialization
	void Start () {
		Instantiate (waveTrigger);
	}

	public void spawnWave(){
		wavenumber++;
		int numberOfEnemies = wavenumber;


		for (int i = 0; i < numberOfEnemies; i++) {
			GameObject enemy = getRandomEnemy ();
			Vector3 spawnLocation = getRandomSpawnLocation ();

			Instantiate (enemy, spawnLocation,new Quaternion());
		}
	}

	private GameObject getRandomEnemy(){
		return spawnableEnemies[Random.Range(0,spawnableEnemies.Length-1)];
	}

	private Vector3 getRandomSpawnLocation(){
		Vector2 spawnLocation = Random.insideUnitCircle * (maxDistanceFromCenter-minDistanceFromCenter);

		// move min dist away from center
		spawnLocation.x += minDistanceFromCenter * Mathf.Sign (spawnLocation.x);
		spawnLocation.y += minDistanceFromCenter * Mathf.Sign (spawnLocation.y);

		return new Vector3 (spawnLocation.x, spawnLocation.y,0);
	}
		

	public void newWaveTrigger(){
		if (GameObject.Find ("TriggerArea") == null) {
			Instantiate (waveTrigger);
		}
	}
}
