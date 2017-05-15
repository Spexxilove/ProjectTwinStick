using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField]
	private float initialHealth = 5.0f;
	private float currentHealth;
	public bool isAlive;

	// Use this for initialization
	void Start () {
		currentHealth = initialHealth;
		isAlive = true;
	}

	public float takeDamage(float damage){
		currentHealth -= damage;
		if (currentHealth <= 0.0f) {
			isAlive = false;
			die ();
		}
		return currentHealth;
	}

	public float getHealth(){
		return currentHealth;
	}

	// do explosions and things here
	private void die(){
		Destroy (gameObject);
	}
}
