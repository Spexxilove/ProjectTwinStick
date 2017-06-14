using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class manages temporary multipliers to stats caused by status effects
// this class is used for enemies and the player
public class StatusEffectManager : MonoBehaviour {

	volatile public float movementspeedMulti =1.0f;
	volatile public float shotDelayMulti =1.0f;
	volatile public float damageMulti = 1.0f;
	volatile public float damageTakenMulti =1.0f;
	volatile public float shotspeedMulti =1.0f;

}
