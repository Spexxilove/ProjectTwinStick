using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisableOnPlayerHasPierce : MonoBehaviour {

	void OnEnable () {
		GameObject player = GameObject.Find ("Player");
		if (player == null)
			return;
		if (player.GetComponent<playerShootingScript> ().hasPierce) {
			GetComponent<Button>().interactable = false;
		} else {
			GetComponent<Button>().interactable = true;
		}
	}
}
