using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeek : MonoBehaviour {

	[SerializeField]
	private float movementSpeed = 5.0f;

	[SerializeField]
	private float rotateSpeed = 45.0f;

	GameObject target;
	Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		if (target == null) {
			print ("no player object found");
			Destroy (gameObject);
		}
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		if (rigidBody == null) {
			print ("no rigidbody found");
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		faceTarget ();
		rigidBody.MovePosition (rigidBody.position+(Vector2)rigidBody.transform.up * movementSpeed * Time.fixedDeltaTime);
	}

	private void faceTarget (){
		
		//rotate to face target

		Vector3 direction = target.transform.position-transform.position;
		float angle = -Vector3.Angle(transform.up,direction)*Mathf.Sign(Vector3.Dot(transform.right,direction));
		angle = Mathf.Clamp (angle, -rotateSpeed, rotateSpeed);
		rigidBody.MoveRotation(rigidBody.rotation+angle);


	}


}
