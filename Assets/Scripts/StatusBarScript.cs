using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarScript : MonoBehaviour {

	[SerializeField]
	private Image contentBar;

	[SerializeField]
	private Text contentText;


	private float maxValue; // max value of shown stat
	private float minValue; // min value of shown stat
	private float initValue;
	[SerializeField]
	private string statText; // displays as "[statText]: [currentValue] / [maxValue]"

	private Health healthScript;

	private float currentValue;

	// Use this for initialization
	void Start () {
		healthScript = GameObject.Find ("Player").GetComponent<Health> ();
		currentValue = healthScript.getHealth();
		maxValue = healthScript.maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		updateBar ();
	}

	public void updateBar(){
		currentValue = healthScript.getHealth();
		contentText.text = statText + ": " + currentValue + " / " + maxValue;
		contentBar.fillAmount = (currentValue - minValue) / (maxValue - minValue);
	}


}
