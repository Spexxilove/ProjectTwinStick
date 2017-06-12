using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour {

	private float healAmount =1.0f;

	void OnCollisionEnter2D(Collision2D collision){
		GameObject other = collision.gameObject;
		if (other.CompareTag ("Player")) {
			Health health = other.GetComponent<Health> ();
			if (health.getHealth () < health.maxHealth) {
				health.heal (healAmount);
				Destroy (gameObject);
			}
		}
	}
}
