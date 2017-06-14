using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerMineExplosion : MonoBehaviour {

	[SerializeField]
	private float explosionDelay;
	[SerializeField]
	private float explosionDamage;

	[SerializeField]
	private float explosionRadius;

	[SerializeField]
	private GameObject explosionZone; //needs to have radius 1

	private StatusEffectManager statusEffectManager;

	void Awake(){
		statusEffectManager = GetComponent<StatusEffectManager> ();
	}

	void Start(){
		drawDangerZone ();
	}

	private void drawDangerZone(){
		GameObject dangerZone = Instantiate (explosionZone, this.transform.position,Quaternion.identity);
		dangerZone.transform.SetParent (this.transform);
		Vector3 areaScale = dangerZone.transform.localScale;
		areaScale.Scale (new Vector3 (explosionRadius, explosionRadius, 1));
		dangerZone.transform.localScale=areaScale;
	}

	
	// Update is called once per frame
	void Update () {
		explosionDelay -= Time.deltaTime/ statusEffectManager.shotDelayMulti;
		if (explosionDelay <= 0)
			triggerExplosion ();
	}

	private void triggerExplosion(){
		dealAoEDamage ();
		Health ownHealth = GetComponent<Health> ();
		ownHealth.takeDamage (ownHealth.currentHealth);
	}

	private void dealAoEDamage(){
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll (transform.position, explosionRadius);
		foreach (Collider2D hitCollider in hitColliders) {
			Health health = hitCollider.gameObject.GetComponent<Health> ();
			if (health != null) {
				health.takeDamage (explosionDamage* statusEffectManager.damageMulti);
			}
		}
	}
}
