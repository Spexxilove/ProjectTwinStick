using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_PoisonOnHit :   Upgrade {

	private static float poisonChance = 0.25f;

	public Upgrade_PoisonOnHit(){
		name = "Chance To Poison";
		numberOfUses = 1;
	}

	public override void applyUpgrade(){
		GameObject player = GameObject.Find ("Player");
		playerShootingScript playerShooting = player.GetComponent<playerShootingScript> ();
		playerShooting.addOnHitEffect (poisonOnHit);
	}

	public static void poisonOnHit(Collider2D other, ref float damageAmount){
		if(Random.value <= poisonChance){
			StatusEffect_Poison poisonEffect = other.gameObject.GetComponent<StatusEffect_Poison>();
			if(poisonEffect == null){
				other.gameObject.AddComponent<StatusEffect_Poison> ();
			}
		}
	}
}