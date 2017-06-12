using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

	public delegate void EnemyDeathEffectHandler(GameObject enemy);

	public event EnemyDeathEffectHandler OnEnemyDeath;

	void Start(){	
		OnEnemyDeath += EnemyRegistration.getDefaultEnemyDeathEffects ();
	}

	public void onEnemyDeath ()
	{
		OnEnemyDeath (this.gameObject);
	}




}
