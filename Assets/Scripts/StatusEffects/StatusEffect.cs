using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : MonoBehaviour {

	protected abstract void startEffect ();
	protected abstract void updateEffect (float deltaTime);
	protected abstract void endEffect ();

}
