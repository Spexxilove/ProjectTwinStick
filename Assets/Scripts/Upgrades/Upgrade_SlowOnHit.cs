using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_SlowOnHit :   Upgrade {

	private static float slowChance = 0.25f;

	public Upgrade_SlowOnHit(){
		name = "ChanceToSlow";
		numberOfUses = 1;
	}

	public override void applyUpgrade(){
		GameObject player = GameObject.Find ("Player");
		playerShootingScript playerShooting = player.GetComponent<playerShootingScript> ();
		playerShooting.addOnHitEffect (slowOnHit);
	}

	public static void slowOnHit(Collider2D other, ref float damageAmount){
		if(Random.value <= slowChance){
			StatusEffect_Slow slowEffect = other.gameObject.GetComponent<StatusEffect_Slow>();
			if(slowEffect == null){
				other.gameObject.AddComponent<StatusEffect_Slow> ();
			}
		}
	}
}

