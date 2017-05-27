using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisableOnPLayerFullHealth : MonoBehaviour {

	void OnEnable () {
		GameObject player = GameObject.Find ("Player");
		if (player == null)
			return;
		if (player.GetComponent<Health> ().isFullHealth ()) {
			GetComponent<Button>().interactable = false;
		} else {
			GetComponent<Button>().interactable = true;
		}
	}
}
