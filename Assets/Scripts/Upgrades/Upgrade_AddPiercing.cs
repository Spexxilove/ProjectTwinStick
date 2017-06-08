using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_AddPiercing : Upgrade {

	public Upgrade_AddPiercing(){
		name = "Piercing Shot";
		numberOfUses = 1;
	}

	public override void applyUpgrade(){
		GameObject player = GameObject.Find ("Player");
		playerShootingScript playerShooting = player.GetComponent<playerShootingScript> ();
		playerShooting.setPiercing (true);
	}
}
