﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttackButton : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("right") && GetComponent<FightMenuButton>().isSelected){
			GetComponent<Toggle>().isOn = true;
			FindObjectOfType<FightGround>().EnterTargetSelection("A");
			FindObjectOfType<FightMenuFrame>().ActivateTargetPanel(true);
			FindObjectOfType<FightMenu>().ActivateMenu(false);
		}
	}
}
