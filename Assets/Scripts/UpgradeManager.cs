using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

	private GameObject player;
	private PlayerController playerController;
	private playerShootingScript playerShooting;
	private GameController gameController;

	[SerializeField]
	private float fireRateUpMultiplier; // between 0 and 1
	[SerializeField]
	private float damageUpAmount; // amount added per damage up
	[SerializeField]
	private float upgradeHealAmount;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		playerController = player.GetComponent<PlayerController> ();
		playerShooting = player.GetComponent<playerShootingScript> ();

		gameController = GameObject.Find ("GameController").GetComponent<GameController>();
	}
	

	//damage up default
	public void damageUp(){
		damageUp (damageUpAmount);
		upgradeComplete ();
	}
	public void damageUp (float amount){
		playerShooting.shotDamage+=amount;
	}

	//firerate up default
	public void fireRateUp(){
		fireRateUp (fireRateUpMultiplier);
		upgradeComplete ();
	}
	public void fireRateUp(float multiplier){
		playerShooting.fireDelay *= multiplier;
	}

	private void upgradeComplete(){
		gameController.endUpgradePhase ();
	}

	public void addCannon(){
		playerShooting.addCannon ();
		upgradeComplete ();
	}

	public void setPiercing(){
		playerShooting.setPiercing (true);
		upgradeComplete ();
	}

	public void healPlayer(){
		player.GetComponent<Health> ().heal (upgradeHealAmount);
		upgradeComplete ();
	}
}
