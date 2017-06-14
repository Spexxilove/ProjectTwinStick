using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShootingScript : MonoBehaviour {

	[SerializeField]
	private float fireDelay =1.0f; //time between shots in seconds
	private float timeSinceShot = 0.0f;
	[SerializeField]
	public float shotSpeed =1.0f;
	[SerializeField]
	private float shotSurvivalTime =2.0f;
	[SerializeField]
	public float shotDamage  =1.0f ;
	[SerializeField]
	public bool hasPierce  { get; private set; }
	[SerializeField]
	private GameObject shotObject;

	private ShotScript.onHitEffectHandler onHitEffects;

	//reference points for cannons
	[SerializeField]
	private GameObject playerCannonLeft;
	[SerializeField]
	private GameObject playerCannonFront;
	[SerializeField]
	private GameObject playerCannonRight;

	[SerializeField]
	private AudioClip[] shotSounds;

	[SerializeField]
	private GameObject[] playerCannons;

	private GameController gameController;
	private StatusEffectManager statusEffectManager;

	// Use this for initialization
	void Awake () {
			hasPierce=false;
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		statusEffectManager = GetComponent<StatusEffectManager> ();
		addCannon ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.isPaused)
			return;
		updateActionInput ();
	}

	private void updateActionInput(){
		timeSinceShot -= Time.deltaTime / statusEffectManager.shotDelayMulti;

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
			shotScript.damage = shotDamage * statusEffectManager.damageMulti;
			shotScript.shotSpeed = shotSpeed * statusEffectManager.shotspeedMulti;
			shotScript.aliveTime = shotSurvivalTime;
			shotScript.isPiercing = hasPierce;
			shotScript.targetTag = "Enemy";
			shotScript.onHitEffects += onHitEffects;
		}
		playRandomShotSound ();
	}

	private void playRandomShotSound(){
		AudioSource.PlayClipAtPoint (shotSounds [Random.Range (0, shotSounds.Length)], transform.position);
	}

	public void addCannon (){
		
		foreach(GameObject oldCannon in playerCannons){
			Destroy(oldCannon);
		}

		int numberOfCannons = playerCannons.Length  + 1;
		playerCannons = new GameObject[numberOfCannons];

		// front cannon if number of cannons is odd
		if (numberOfCannons % 2 == 1) {
			playerCannons[playerCannons.Length-1]=Instantiate ( playerCannonFront, playerCannonFront.transform.position, playerCannonFront.transform.rotation, transform);
			numberOfCannons--;
		}

		if (numberOfCannons>0) {
			// left cannons
			Vector3 position = playerCannonLeft.transform.position;
			Vector3 spacing = (playerCannonFront.transform.position - playerCannonLeft.transform.position);
			spacing*=1.0f / (numberOfCannons / 2.0f);
			for (int i = 0; i < numberOfCannons / 2; i++) {
				playerCannons [i] = Instantiate (playerCannonFront, position, playerCannonFront.transform.rotation, transform);
				position += spacing;
			}

			// right cannons
			position = playerCannonRight.transform.position;
			spacing = (playerCannonFront.transform.position - playerCannonRight.transform.position);
			spacing*= (1.0f / (numberOfCannons / 2.0f));
			for (int i = numberOfCannons / 2; i < numberOfCannons; i++) {
				playerCannons [i] = Instantiate (playerCannonFront, position, playerCannonFront.transform.rotation, transform);
				position += spacing;
			}
		}

	}

	public void setPiercing(bool enabled){
		hasPierce = enabled;
	}

	public void fireRateChange(float multiplier){
		fireDelay *= multiplier;
	}

	public void shotSpeedChange(float amount){
		shotSpeed += amount;
	}

	public void addOnHitEffect(ShotScript.onHitEffectHandler onHitEffect){
		onHitEffects += onHitEffect;
	}
}
