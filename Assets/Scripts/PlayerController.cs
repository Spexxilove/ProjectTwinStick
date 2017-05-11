using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float movementspeed =1.0f;

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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		updateActionInput ();
	}

	void FixedUpdate () {
		updateMovement ();
	}

	private void updateMovement(){
		//translate
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");

		Vector2 inputVector = new Vector2 (horizontal, vertical);
		inputVector.Normalize ();

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.MovePosition (new Vector2(transform.position.x,transform.position.y)+inputVector * movementspeed * Time.fixedDeltaTime);

		//rotate player to face pointer
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(ray,out hit)){
			Vector3 direction = hit.point-transform.position;
			direction.z = transform.position.z;

			rb.MoveRotation(rb.rotation-Vector3.Angle(transform.up,direction)*Mathf.Sign(Vector3.Dot(transform.right,direction)));
		}
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
		GameObject shotInstance = Instantiate (shotObject,this.transform.position,this.transform.rotation);
		ShotScript shotScript = shotInstance.GetComponent<ShotScript> ();
		shotScript.damage = shotDamage;
		shotScript.shotSpeed = shotSpeed;
		shotScript.aliveTime = shotSurvivalTime;
	}
}
