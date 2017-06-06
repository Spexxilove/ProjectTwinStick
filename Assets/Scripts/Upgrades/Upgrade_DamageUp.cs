using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Upgrade_DamageUp : Upgrade {

	private static float damageUpAmount = 1.0f;

	public Upgrade_DamageUp(){
		name = "Damage Up";
	}

	public override void applyUpgrade(){
		GameObject player = GameObject.Find ("Player");
		playerShootingScript playerShooting = player.GetComponent<playerShootingScript> ();
		playerShooting.shotDamage+=damageUpAmount;
	}
}
