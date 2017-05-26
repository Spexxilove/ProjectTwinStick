using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UI_WaveCounter : MonoBehaviour {

	[SerializeField]
	private Text waveNumberText;
	private WaveGenerator waveGenerator;
	// Use this for initialization
	void Start () {
		waveGenerator = GameObject.Find ("GameController").GetComponent<WaveGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
		waveNumberText.text = waveGenerator.wavenumber.ToString();
	}
}
