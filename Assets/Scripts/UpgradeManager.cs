using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

	private GameController gameController;

	private List<Upgrade> upgradePool;

	// contains upgrades that are currently available
	private List<Upgrade> currentUpgrades;

	[SerializeField]
	private List<Button> upgradeButtons;


	// Use this for initialization
	void Start () {
		initUpgradePool ();
		gameController = GameObject.Find ("GameController").GetComponent<GameController>();
	}

	// initialise upgrade pool
	// TODO: find a better way to add one of each upgrade
	private void initUpgradePool (){
		upgradePool = new List<Upgrade> ();
		upgradePool.Add (new Upgrade_DamageUp ());
		upgradePool.Add (new Upgrade_FirerateUp ());
		upgradePool.Add (new Upgrade_AddCannon ());
		upgradePool.Add (new Upgrade_MovementspeedUp ());
		upgradePool.Add (new Upgrade_ShotspeedUp());
		upgradePool.Add (new Upgrade_AddPiercing ());
		upgradePool.Add (new Upgrade_SlowOnHit ());
	}

	// removes random upgrade from pool and returns it
	public Upgrade getRandomUpgrade(){
		int index = Random.Range (0, upgradePool.Count);
		Upgrade up = upgradePool [index];
		upgradePool.RemoveAt (index);
		return up;
	}

	public void startUpgradePhase(){
		currentUpgrades = new List<Upgrade> ();
		foreach (Button button in upgradeButtons) {
			Upgrade up = getRandomUpgrade ();
			currentUpgrades.Add (up);
			button.transform.Find ("Text").GetComponent<Text> ().text = up.name;
		}
	}

	public void chooseUpgrade(int index){
		Upgrade chosenUpgrade = currentUpgrades [index];
		chosenUpgrade.applyUpgrade ();

		// reduce number of uses and remove upgrade if out of uses
		if (chosenUpgrade.numberOfUses > 0) {
			chosenUpgrade.numberOfUses--;
			if(chosenUpgrade.numberOfUses== 0)
				currentUpgrades.RemoveAt (index);
		}

		// return remaining upgrades to pool
		upgradePool.AddRange (currentUpgrades);
		currentUpgrades = new List<Upgrade> ();
		upgradeComplete ();
	}

	private void upgradeComplete(){
		gameController.endUpgradePhase ();
	}
}
