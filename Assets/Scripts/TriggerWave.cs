using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// triggers wave when player stays within trigger for certain amount of time
// is destroyed when wave triggers.
public class TriggerWave : MonoBehaviour {

	[SerializeField] 
	private float spawnTimer =1.0f; // time player has to be in area for to trigger the next wave
	private float currentTimer = 0.0f;

	private bool insideTrigger = false;
	private GameObject gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");

	}

	void Update(){
		if (insideTrigger) {
			currentTimer += Time.deltaTime;
			if (currentTimer >= spawnTimer) {
				triggerWave ();

			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.transform.root.CompareTag ("Player")) {
			insideTrigger = true;
		}
	}
		

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform.root.CompareTag ("Player")) {
			insideTrigger = false;
			currentTimer = 0.0f; // reset timer
		}

	}

	private void triggerWave(){
		gameController.GetComponent<WaveGenerator> ().spawnWave ();
		Destroy (gameObject);
	}
}
