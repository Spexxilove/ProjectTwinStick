using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject GameOverWindow;

	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null || !player.GetComponent<Health>().isAlive)
		{
			GameOverWindow.SetActive(true);
			return;
		}
	}
}
