using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenManager : MonoBehaviour {

	public void toMainMenu(){
		SceneManager.LoadScene ("_mainMenu");
	}

	public void tryAgain(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
