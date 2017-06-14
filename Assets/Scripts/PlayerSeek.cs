using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeek : MonoBehaviour {

	[SerializeField]
	private float movementSpeed = 5.0f;

	[SerializeField]
	private float rotateSpeed = 45.0f;

	private GameObject target;
	private Rigidbody2D rigidBody;
	private StatusEffectManager statusEffectManager;
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		statusEffectManager = gameObject.GetComponent<StatusEffectManager> ();
	}

	void FixedUpdate () {
		if (target != null) {
			faceTarget ();
			rigidBody.MovePosition (rigidBody.position + (Vector2)rigidBody.transform.up * movementSpeed * statusEffectManager.movementspeedMulti * Time.fixedDeltaTime);
		}
	}

	private void faceTarget (){
		
		//rotate to face target
		Vector3 direction = target.transform.position-transform.position;
		float angle = -Vector3.Angle(transform.up,direction)*Mathf.Sign(Vector3.Dot(transform.right,direction));
		float currentRotationSpeed = rotateSpeed * statusEffectManager.movementspeedMulti;
		angle = Mathf.Clamp (angle, -currentRotationSpeed, currentRotationSpeed);
		rigidBody.MoveRotation(rigidBody.rotation+angle);


	}


}
