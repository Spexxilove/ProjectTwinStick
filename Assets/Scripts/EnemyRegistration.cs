using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemies register to default effects (e.g. on death pickup spawn or on death registration) over this class

public class EnemyRegistration : MonoBehaviour {

	private static volatile EnemyDeath.EnemyDeathEffectHandler defaultEnemyDeathEffects;

	public void addDefaultEnemyDeathEffect(EnemyDeath.EnemyDeathEffectHandler deathEffect){
		defaultEnemyDeathEffects += deathEffect;
	}

	public static EnemyDeath.EnemyDeathEffectHandler getDefaultEnemyDeathEffects(){
		return  defaultEnemyDeathEffects;
	}

}
