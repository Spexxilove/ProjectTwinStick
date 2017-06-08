using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_FirerateUp : Upgrade {

	private float firerateMultiplier = 0.9f;

	public Upgrade_FirerateUp(){
		name = "Firerate Up";
		numberOfUses = -1;
	}

	public override void applyUpgrade(){
		GameObject player = GameObject.Find ("Player");
		playerShootingScript playerShooting = player.GetComponent<playerShootingScript> ();
		playerShooting.fireRateChange (firerateMultiplier);
	}
}

