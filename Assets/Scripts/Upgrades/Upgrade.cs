using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Upgrade {
	public string name;
	// how often an upgrade can be applied befor removed from pool. <0 for infinite uses;
	public int numberOfUses;
	public abstract void applyUpgrade ();

}
