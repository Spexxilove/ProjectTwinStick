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
		UpgradeWindow.SetActive (true);
		isUpgrading = true;
		pause ();
	}

	public void endUpgradePhase ()
	{
		UpgradeWindow.SetActive (false);
		isUpgrading = false;
		unPause ();
	}

	public void endWave ()
	{
		
		startUpgradePhase ();
		GetComponent<WaveGenerator> ().newWaveTrigger ();

	}
}
