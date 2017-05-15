using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject GameOverWindow;
	public GameObject PausedWindow;
	public bool isPaused { get; private set; }


	private GameObject player;
	// Use this for initialization
	void Start () {
		unPause ();
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused)
			return;
		if (Input.GetButtonDown("Cancel")) {
			Time.timeScale = 0.0f;
			isPaused = true;
			PausedWindow.SetActive (true);
		}

		if(player == null || !player.GetComponent<Health>().isAlive)
		{
			
			GameOverWindow.SetActive(true);
			return;
		}
	}

	public void unPause(){
		if (isPaused) {
			isPaused = false;
			Time.timeScale = 1.0f;
		}
	}
}
