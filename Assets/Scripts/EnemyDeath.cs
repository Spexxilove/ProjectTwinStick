using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

	public void onEnemyDeath ()
	{

		WaveGenerator wGenerator = GameObject.Find ("GameController").GetComponent<WaveGenerator> ();
		wGenerator.enemyKilled ();

	}
}
