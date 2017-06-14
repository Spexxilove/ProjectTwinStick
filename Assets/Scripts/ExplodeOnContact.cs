using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnContact : MonoBehaviour {

	[SerializeField]
	private float contactDamage =1.0f;

	void OnCollisionEnter2D(Collision2D collision){
		GameObject collisionObj = collision.gameObject;
		if (collisionObj.CompareTag ("Player")) {
			float damageMulti = GetComponent<StatusEffectManager> ().damageMulti;
			collisionObj.GetComponent<Health> ().takeDamage (contactDamage*damageMulti);
			Health h = GetComponent<Health> ();
			h.takeDamage (h.getHealth());
		}
	}
}
