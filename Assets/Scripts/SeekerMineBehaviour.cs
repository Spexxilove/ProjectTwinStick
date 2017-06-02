using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// seekermine does nothing until the player comes close enough, then it moves towards the player until within armingdistance.
// then it explodes after a timer dealing areaDamage.
public class SeekerMineBehaviour : MonoBehaviour {

	[SerializeField]
	private float wakeUpDistance;
	[SerializeField]
	private float armingDistance;

	private bool isAwake = false;
	private bool isArmed = false;
	private GameObject player;
	// Use this for initialization
	void Start () {
		// square distance for cheaper computation
		wakeUpDistance = Mathf.Pow (wakeUpDistance, 2);
		armingDistance = Mathf.Pow (armingDistance, 2);
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null)
			return;
		
		if (!isArmed) 
			checkPlayerDistance();	
	}

	private void checkPlayerDistance(){
		float distance = (player.transform.position - transform.position).sqrMagnitude;
		if (!isAwake && distance <= wakeUpDistance) {
			isAwake = true;
			gameObject.GetComponent<SeekerMineMovement> ().enabled = true;
		}else if(!isArmed && distance <= armingDistance){
			isArmed = true;
			gameObject.GetComponent<SeekerMineMovement> ().enabled = false;
			gameObject.GetComponent<SeekerMineExplosion> ().enabled = true;
		}

	}
}
