using UnityEngine;
using System.Collections;

public class FightMenuPrime : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void QuietOtherButtons (FightMenuButton button) {
		FightMenuButton[] fightMenuButtons = FindObjectsOfType<FightMenuButton> ();
		foreach (FightMenuButton fightMenuButton in fightMenuButtons) {
			if (fightMenuButton.hasSubMenu){
				if(fightMenuButton != button){
					fightMenuButton.ChangeSprite (fightMenuButton.subMenuActiveSprite);
				}
			}
		}
	}

}
