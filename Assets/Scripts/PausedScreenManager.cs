using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedScreenManager : MonoBehaviour {

	private GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.isPaused) {
			if (Input.GetButtonDown ("Cancel")) {
				unPause ();
			}
		}
	}

	public void unPause(){
		gameController.unPause ();
		gameObject.SetActive (false);
	}

	public void toMenu(){
		unPause ();
		Destroy(GameObject.Find ("Player"));
		SceneManager.LoadScene ("_mainMenu");
	}
}
