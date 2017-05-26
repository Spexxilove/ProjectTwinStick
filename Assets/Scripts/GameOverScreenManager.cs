using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenManager : MonoBehaviour {

	[SerializeField]
	private Text waveCounter;

	void Start(){
		waveCounter.text = GameObject.Find ("GameController").GetComponent<WaveGenerator> ().wavenumber.ToString();
	}

	public void toMainMenu(){
		SceneManager.LoadScene ("_mainMenu");
	}

	public void tryAgain(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
