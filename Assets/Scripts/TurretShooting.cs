using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour {

	GameObject target;

	[SerializeField]
	private float rotateSpeed;
	[SerializeField]
	private float shootingAngle = 5.0f;
	[SerializeField]
	private float shotDelay = 1.0f;
	[SerializeField]
	private float shotSpeed =1.0f;
	[SerializeField]
	private float shotSurvivalTime =2.0f;
	[SerializeField]
	public float shotDamage  =1.0f ;
	[SerializeField]
	public GameObject cannon ;
	[SerializeField]
	public GameObject shotObject ;
	[SerializeField]
	public AudioClip[] shotSounds ;

	private float reloadTimer = 0.0f;

	private StatusEffectManager statusEffectManager;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player");
		statusEffectManager = GetComponentInParent<StatusEffectManager> ();
	}
		
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null) {
			float angle = faceTarget ();
			reloadTimer -= Time.fixedDeltaTime/statusEffectManager.shotDelayMulti;
			if (angle < shootingAngle && reloadTimer <= 0.0f) {
				fireShot ();
				reloadTimer = shotDelay;
			}
		}
	}

	// rotate towards target and returns angle to go
	private float faceTarget(){
		Vector3 direction = target.transform.position-transform.position;
		float angle = -Vector3.Angle(transform.up,direction)*Mathf.Sign(Vector3.Dot(transform.right,direction));
		float currentRotatespeed = statusEffectManager.movementspeedMulti * rotateSpeed; 
		float angleClamped = Mathf.Clamp (angle, -currentRotatespeed, currentRotatespeed);
		GetComponent<Rigidbody2D>().MoveRotation(GetComponent<Rigidbody2D>().rotation+angleClamped);
		return Mathf.Abs(angle);
	}


	private void fireShot(){
		
		GameObject shotInstance = Instantiate (shotObject, cannon.transform.position, cannon.transform.rotation);
		ShotScript shotScript = shotInstance.GetComponent<ShotScript> ();
		shotScript.damage = shotDamage * statusEffectManager.damageMulti;
		shotScript.shotSpeed = shotSpeed * statusEffectManager.shotspeedMulti;
		shotScript.aliveTime = shotSurvivalTime;
		shotScript.isPiercing = false;
		shotScript.targetTag = "Player";
		playRandomShotSound ();
	}

	private void playRandomShotSound(){
		AudioSource.PlayClipAtPoint (shotSounds [Random.Range (0, shotSounds.Length)], transform.position);
	}
}
