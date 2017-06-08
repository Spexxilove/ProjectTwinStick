using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_MovementspeedUp : Upgrade {

	private float movementSpeedUpAmount = 3.0f;

	public Upgrade_MovementspeedUp(){
		name = "Movementspeed Up";
		numberOfUses = -1;
	}

	public override void applyUpgrade(){
		GameObject player = GameObject.Find ("Player");
		PlayerController playerController = player.GetComponent<PlayerController> ();
		playerController.movementSpeedChange (movementSpeedUpAmount);
	}
}

