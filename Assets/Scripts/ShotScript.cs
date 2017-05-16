using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

	public float shotSpeed = 5.0f; // set by fireing script
	public float aliveTime = 5.0f; // Time before shot is destroyed in seconds . set by fireing script
	public float damage = 1.0f;
	public bool isPiercing =false;
	private float timeSinceInstantiation = 0.0f;

	void FixedUpdate () {
		// move shot
		transform.Translate (Vector3.up*Time.fixedDeltaTime*shotSpeed);

		// limit range
		timeSinceInstantiation+= Time.fixedDeltaTime;
		if (timeSinceInstantiation >= aliveTime) {
			Destroy (this.gameObject);
		}
	}


	void OnTriggerEnter2D(Collider2D other){
		string tag = other.tag;

	if (!string.IsNullOrEmpty (tag)) {
			switch (tag) {
			case "Environment":
				environmentHit ();
				break;

			case "Enemy":
				enemyHit (other.gameObject);
				break;
			default:
				break;


			}
		}
	}
		

	private void environmentHit ()
	{
		triggerDeathEffects();
	}

	private void enemyHit(GameObject enemy){
		Health enemyHealth = enemy.GetComponent<Health> ();
		if (enemyHealth == null) {
			return;
		}
		enemyHealth.takeDamage (damage);
		if (!isPiercing) {
			triggerDeathEffects ();
		}

	}

	// effects to trigger when projectiles die on inpact
	private void triggerDeathEffects(){
		Destroy (gameObject);
	}
}
