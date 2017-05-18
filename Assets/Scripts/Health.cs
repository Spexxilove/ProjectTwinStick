using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField]
	private float initialHealth = 5.0f;
	private float currentHealth;
	public bool isAlive=true;

	[SerializeField]
	private ParticleSystem deathEffect;
	[SerializeField]
	private AudioClip[] takeDamageSounds;
	[SerializeField]
	private AudioClip[] DeathSounds;

	// Use this for initialization
	void Start () {
		currentHealth = initialHealth;
		isAlive = true;
	}

	public void takeDamage(float damage){
		if (!isAlive)
			return;
		currentHealth -= damage;
		if (currentHealth <= 0.0f) {
			
			die ();
		} else {
			playRandomSound (takeDamageSounds);
		}
			
	}

	public float getHealth(){
		return currentHealth;
	}

	// do explosions and things here
	private void die(){
		isAlive = false;
		if (CompareTag ("Enemy")) {
			EnemyDeath ed = GetComponent<EnemyDeath> ();
			if (ed != null) {
				ed.onEnemyDeath ();
			}
		}
		playRandomSound (DeathSounds);
		if (deathEffect != null) {
			Instantiate (deathEffect, transform.position, Quaternion.identity);
		}
		Destroy (gameObject);
	}

	private void playRandomSound(AudioClip[] sounds){
		if (sounds != null && sounds.Length > 0) {
			AudioSource.PlayClipAtPoint (sounds [Random.Range (0, sounds.Length)], transform.position);
		}
	}
}
