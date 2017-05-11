using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShootingScript : MonoBehaviour {

	[SerializeField]
	private float fireDelay =1.0f; //time between shots in seconds
	private float timeSinceShot = 0.0f;
	[SerializeField]
	private float shotSpeed =1.0f;
	[SerializeField]
	private float shotSurvivalTime =2.0f;
	[SerializeField]
	private float shotDamage =1.0f;
	[SerializeField]
	private GameObject shotObject;
	[SerializeField]
	private GameObject[] playerCannons;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		updateActionInput ();
	}

	private void updateActionInput(){
		timeSinceShot -= Time.deltaTime;

		if (Input.GetButton("Fire1")) {
			if (timeSinceShot <= 0.0f) {
				//shoot
				fireShot();
				timeSinceShot = fireDelay;
			}
		}
	}

	private void fireShot(){
		foreach (GameObject playerCannon in playerCannons) {
			GameObject shotInstance = Instantiate (shotObject, playerCannon.transform.position, playerCannon.transform.rotation);
			ShotScript shotScript = shotInstance.GetComponent<ShotScript> ();
			shotScript.damage = shotDamage;
			shotScript.shotSpeed = shotSpeed;
			shotScript.aliveTime = shotSurvivalTime;
		}
	}
}
