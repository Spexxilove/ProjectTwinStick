using System.Collections;
using UnityEngine;


	public class DestroyAfterDuration : MonoBehaviour
	{

		private void Start()
		{
		Destroy(gameObject, GetComponent<ParticleSystem>().main.duration); 
		}

	}