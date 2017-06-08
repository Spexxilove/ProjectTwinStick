using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	public GameObject GameOverWindow;
	public GameObject PausedWindow;
	public GameObject UpgradeWindow;

	public bool isPaused  { get; private set; }

	public bool isUpgrading  { get; private set; }

	private GameObject player;
	// Use this for initialization
	void Start ()
	{
		unPause ();
		isUpgrading = false;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isPaused)
			return;
		if (Input.GetButtonDown ("Cancel")) {
			pause ();
			PausedWindow.SetActive (true);
		}

		if (player == null || !player.GetComponent<Health> ().isAlive) {
			
			GameOverWindow.SetActive (true);
			return;
		}
	}

	public void pause ()
	{
		Time.timeScale = 0.0f;
		isPaused = true;
	}

	public void unPause ()
	{
		if (!isUpgrading && isPaused) {
			isPaused = false;
			Time.timeScale = 1.0f;
		}
	}

	public void startUpgradePhase ()
	{
		GetComponent<UpgradeManager> ().startUpgradePhase ();
		UpgradeWindow.SetActive (true);
		isUpgrading = true;
		isPaused = true;
	}

	public void endUpgradePhase ()
	{
		UpgradeWindow.SetActive (false);
		isUpgrading = false;
		isPaused = false;
	}

	public void endWave ()
	{
		//destroy all projectiles on screen
		foreach (GameObject enemyProjectile in GameObject.FindGameObjectsWithTag("EnemyProjectile")) {
			Destroy (enemyProjectile);
		}
		startUpgradePhase ();
		GetComponent<WaveGenerator> ().newWaveTrigger ();

	}
}
