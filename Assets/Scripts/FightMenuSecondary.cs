using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FightMenuSecondary : MonoBehaviour {



	void OnEnable () {
		
		FightMenuButton[] buttons = GetComponentsInChildren<FightMenuButton> ();
		GameObject eventSystem = GameObject.Find ("EventSystem");
		eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (buttons[0].gameObject);
		buttons [0].EmboldenText ();
	}

}
