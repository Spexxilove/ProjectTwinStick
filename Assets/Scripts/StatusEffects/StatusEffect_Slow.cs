using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect_Slow : TimedStatusEffect {

	private static float slowMultiplier = 0.5f;

	private StatusEffectManager statusEffectManager;

	void Awake(){
		statusEffectManager = GetComponent<StatusEffectManager> ();
		duration = 3.0f;
	}
		

	protected override void startEffect ()
	{
		statusEffectManager.movementspeedMulti *= slowMultiplier;
	}

	protected override void endEffect ()
	{
	statusEffectManager.movementspeedMulti /= slowMultiplier;
	}

	protected override void updateEffect (float deltaTime)
	{
		
	}
}
