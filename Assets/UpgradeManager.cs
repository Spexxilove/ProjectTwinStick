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
}