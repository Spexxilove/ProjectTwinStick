using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour {

	public int wavenumber { get; private set; }
	private int numberOfAliveEnemies = 0;

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
		wavenumber = 0;
		Instantiate (waveTrigger);
		GetComponent<EnemyRegistration> ().addDefaultEnemyDeathEffect(this.checkWinCondition);
	}

	public void spawnWave(){
		wavenumber++;
		int numberOfEnemies = wavenumber;

		numberOfAliveEnemies += numberOfEnemies;
		for (int i = 0; i < numberOfEnemies; i++) {
			GameObject enemy = getRandomEnemy ();
			Vector3 spawnLocation = getRandomSpawnLocation ();

			GameObject spawnedEnemy = Instantiate (enemy, spawnLocation,new Quaternion());
			spawnedEnemy.transform.Rotate(Vector3.forward,Random.Range(0,359));
		}
	}

	private GameObject getRandomEnemy(){
		return spawnableEnemies[Random.Range(0,spawnableEnemies.Length)];
	}

	private Vector3 getRandomSpawnLocation(){
		Vector2 spawnLocation = Random.insideUnitCircle * (maxDistanceFromCenter-minDistanceFromCenter);

		// move min dist away from center
		spawnLocation  += spawnLocation.normalized*minDistanceFromCenter ;


		return new Vector3 (spawnLocation.x, spawnLocation.y,0);
	}
		

	public void newWaveTrigger(){
		if (GameObject.Find ("TriggerArea") == null) {
			Instantiate (waveTrigger);
		}
	}

	public void enemyKilled(){
		numberOfAliveEnemies--;
		if (numberOfAliveEnemies == 0)
			gameObject.GetComponent<GameController> ().endWave ();;
	}

	public void checkWinCondition(GameObject enemy){
		enemyKilled ();
	}
}
