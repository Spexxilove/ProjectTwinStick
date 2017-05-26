using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// move straight towards player
public class SeekerMineMovement : MonoBehaviour {

	private GameObject player;
	[SerializeField]
	private float movementSpeed = 0.1f;
	private Rigidbody2D rigidBody;

	void Start () {
		player = GameObject.Find ("Player");
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		Vector2 direction = (player.transform.position - transform.position).normalized;
		rigidBody.MovePosition (rigidBody.position + direction * movementSpeed);
	}
}
