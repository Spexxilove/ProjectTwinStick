using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] pickupObjects;
	[SerializeField]
	private float[] spawnProbability;

	// Use this for initialization
	void Start () {
		EnemyRegistration registration = GetComponent<EnemyRegistration> ();
		registration.addDefaultEnemyDeathEffect (this.spawnPickupsOnEnemyDeath);
	}

	public void spawnPickupsOnEnemyDeath(GameObject enemy){
		for (int i = 0; i < pickupObjects.Length; i++) {
			if (Random.value <= spawnProbability [i]) {
				Instantiate (pickupObjects [i], enemy.transform.position, Quaternion.identity);
			}
		}
	}
}
