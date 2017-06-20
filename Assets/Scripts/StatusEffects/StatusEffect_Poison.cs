using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect_Poison :  TimedStatusEffect {

	private static float damageAmount = 0.5f;
	private static float damageInterval = 1; 

	private float damageCountdown;

	private Health health;

	void Awake(){
		damageCountdown = damageInterval;
		health = GetComponent<Health> ();
		duration = 3.0f;
	}


	protected override void startEffect ()
	{
	}

	protected override void endEffect ()
	{
	}

	protected override void updateEffect (float deltaTime)
	{
		damageCountdown -= deltaTime;
		if (damageCountdown <= 0) {
			health.takeDamage (damageAmount);
			damageCountdown += damageInterval;
		}
	}
}
