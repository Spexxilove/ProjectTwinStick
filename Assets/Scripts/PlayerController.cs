using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float movementspeed =1.0f;
	private GameController gameController;

	void Start(){
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	}

	void FixedUpdate () {
		if (!gameController.isPaused) {
			updateMovement ();
		}
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


}
