using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

	public delegate void EnemyDeathEffectHandler(GameObject enemy);

	public event EnemyDeathEffectHandler OnEnemyDeath;

	void Start(){		
		OnEnemyDeath += checkWinCondition;
	}

	public void onEnemyDeath ()
	{
		OnEnemyDeath (this.gameObject);
	}

	public static void checkWinCondition(GameObject enemy){
		WaveGenerator wGenerator = GameObject.Find ("GameController").GetComponent<WaveGenerator> ();
		wGenerator.enemyKilled ();
	}


}
