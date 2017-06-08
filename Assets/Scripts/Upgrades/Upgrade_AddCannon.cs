using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_AddCannon : Upgrade {



	public Upgrade_AddCannon(){
		name = "Add Cannon";
		numberOfUses = 3;
	}

	public override void applyUpgrade(){
		GameObject player = GameObject.Find ("Player");
		playerShootingScript playerShooting = player.GetComponent<playerShootingScript> ();
		playerShooting.addCannon ();
	}
}
