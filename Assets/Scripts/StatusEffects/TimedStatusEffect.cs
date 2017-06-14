using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimedStatusEffect : StatusEffect {

	protected float duration;

	void OnEnable(){
		startEffect ();
	}

	void Update () {
		updateEffect (Time.deltaTime);
		duration -= Time.deltaTime;
		if (duration <= 0) {
			endEffect ();
			Destroy (this);
		}
	}


}
