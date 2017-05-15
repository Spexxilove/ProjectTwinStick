using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour {

	void OnDestroy(){
		
		GameObject.Find ("GameOverScreen").SetActive (true);
	}
}
