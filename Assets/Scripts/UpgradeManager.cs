﻿using System.Collections;
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
	[SerializeField]
	private float movementSpeedUpAmount;
	[SerializeField]
	private float shotspeedUpAmount;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		playerController = player.GetComponent<PlayerController> ();
		playerShooting = player.GetComponent<playerShootingScript> ();

		gameController = GameObject.Find ("GameController").GetComponent<GameController>();
	}
	

	//damage up default
	public void damageUp(){
		Upgrade_DamageUp dmgUp = new Upgrade_DamageUp ();
		dmgUp.applyUpgrade ();
		upgradeComplete ();
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

	public void movementSpeedUp(){
		playerController.movementSpeedChange (movementSpeedUpAmount);
		upgradeComplete ();
	}

	public void shotSpeedUp(){
		playerShooting.shotSpeed += shotspeedUpAmount;
		upgradeComplete ();
	}
}
