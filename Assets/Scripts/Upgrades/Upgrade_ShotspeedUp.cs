using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_ShotspeedUp :  Upgrade {

	private float shotspeedUpAmount = 3.0f;

	public Upgrade_ShotspeedUp(){
		name = "Shotspeed Up";
		numberOfUses = -1;
	}

	public override void applyUpgrade(){
		GameObject player = GameObject.Find ("Player");
		playerShootingScript playerShooting = player.GetComponent<playerShootingScript> ();
		playerShooting.shotSpeedChange (shotspeedUpAmount);
	}
}

